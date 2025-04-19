using ASP.NETCoreApplication;


var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

builder.Services.AddOpenApi();

var app = builder.Build();

startup.Configure(app);

app.Run();
