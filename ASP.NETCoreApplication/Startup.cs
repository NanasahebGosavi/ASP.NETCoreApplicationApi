using ASP.NETCoreApplication.Context;
using ASP.NETCoreApplication.Interface;
using ASP.NETCoreApplication.Model;
using ASP.NETCoreApplication.Services;
using EFEcommerceApp.Helpers;
 using EFEcommerceApp.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace EFEcommerceApp
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // ConfigureServices method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));
            services.AddControllers(); // Add MVC or Web API controllers

            services.Configure<AppSettings>(_configuration.GetSection("AppSettings"));
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IProduct, ProductService>();
           services.AddScoped<IEmployee ,  EmployeeService>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(); // Add Swagger for API documentation

            #region Swagger Authorize API UI
            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "JWT Token Authentication API",
                    Description = ".NET 8 Web API"
                });
                // To Enable authorization using Swagger (JWT)
                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });
                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

                    }
                });
            });
            #endregion

            // Add Authorization with Role-based policies
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
                options.AddPolicy("EditorPolicy", policy => policy.RequireRole("Editor"));
                options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
            });
            
        }

        // Configure method to set up the request pipeline
        public void Configure(WebApplication app)
        {
            // Middleware pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           
            app.UseHttpsRedirection();
            app.UseAuthorization();

            app.UseMiddleware<JwtMiddleware>();

            app.MapControllers(); // Map controller routes
        }
    }
}
