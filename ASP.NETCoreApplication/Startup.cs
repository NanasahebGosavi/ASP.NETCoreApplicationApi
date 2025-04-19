using ASP.NETCoreApplication.Context;
using ASP.NETCoreApplication.Interface;
using ASP.NETCoreApplication.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
namespace ASP.NETCoreApplication
{
    public class Startup
    {
        public IConfiguration Configuration { get;  }

        public Startup(IConfiguration config)
        {
            Configuration = config;

        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddControllers().AddNewtonsoftJson(); 

            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            services.AddScoped<IProduct, ProductService>();

            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
           
            services.AddSwaggerGen();
        }
        public void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "DemoApi");
                });
                app.MapScalarApiReference(options =>
                {
                    options
                       .WithTitle("Demo Api")
                       .WithTheme(ScalarTheme.Mars)
                       .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.Http);
                });

            }
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>

                {
                   context.Response.StatusCode = 500;
                     context.Response.ContentType = "application/json";
                 var error = context.Features.Get<IExceptionHandlerPathFeature>() ?. Error;

                   await context.Response.WriteAsJsonAsync(new
                   {
                       Message = "Global Exception : Something Went Wrong ",
                       Detail = error ?. Message
   

                   });
               });

            });
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseRouting();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllers();
            });
        }
    }
}
