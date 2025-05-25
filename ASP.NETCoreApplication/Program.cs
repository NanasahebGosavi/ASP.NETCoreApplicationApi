using ASP.NETCoreApplication.Interface;
using ASP.NETCoreApplication.Services;
using EFEcommerceApp;
using EFEcommerceApp.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi.Services;

using ASP.NETCoreApplication;

var builder = WebApplication.CreateBuilder(args);

// Use the Startup class for configuration 
var startup = new Startup(builder.Configuration);

// Configure services
startup.ConfigureServices(builder.Services);

// Register Authentication
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = "Bearer";
//    options.DefaultChallengeScheme = "Bearer";
//})


// Other services
builder.Services.AddScoped<IProduct, ProductService>();
builder.Services.AddScoped<TokenService>();

builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{

    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true, 
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

// Add Authorization
builder.Services.AddAuthorization();

var app = builder.Build(); 

// Configure middleware
startup.Configure(app);

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

app.Run();
