using AuthServer.DataProvider.Infrastructure.HostedServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenIddictStorage(builder.Configuration);
builder.Services.AddHostedService<AuthorizationSettingsWorker>();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

app.Run();
