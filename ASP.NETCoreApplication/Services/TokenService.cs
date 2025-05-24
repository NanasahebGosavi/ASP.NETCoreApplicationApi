using ASP.NETCoreApplication.Model;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace WebApi.Services
{
    public class TokenService
    {

        private readonly IConfiguration _config;
        private readonly AppSettings _appSetting;

        public TokenService(IConfiguration config, IOptions<AppSettings> appSetting)
        {
            _config = config;
            _appSetting = appSetting.Value;
        }

        public string GenerateToken(string username)
        {
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

            //var key = new SymmetricSecurityKey(	Encoding.UTF8.GetBytes(_config["Jwt:Key"]!));
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appSetting.Secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}