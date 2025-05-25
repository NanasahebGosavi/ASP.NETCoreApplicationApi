using ASP.NETCoreApplication.Interface;
using ASP.NETCoreApplication.Model;
using ASP.NETCoreApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Services;

namespace ASP.NETCoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthApiController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly TokenService _tokenService;
        public AuthApiController( IUserService userservice , TokenService tokenservice) 
        {
            _tokenService = tokenservice;
            _userService = userservice;

        }
        [HttpPost("Login")] 
        public async Task<IActionResult> Login(AuthenticateRequest model)
        {
            if (model.Username == null || model.Password == null )
            {
                return Ok("Plz Enter User Name And Password ");
            }
            var UserObj = await _userService.Authenticate(model);
            if (UserObj == null)
            {
                return BadRequest("Enter User Name Correct ");
            }
          //  var _token=  _tokenService.GenerateToken(UserObj.Username);
            return Ok(UserObj);
        }

    }
}
