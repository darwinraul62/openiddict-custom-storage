using AuthServer.DataProvider.Infrastructure;
using OpenIddict.Abstractions;

namespace AuthServer.DataProvider.Infrastructure.HostedServices;

public class AuthorizationSettingsWorker : IHostedService
{
    private readonly IServiceProvider serviceProvider;

    public AuthorizationSettingsWorker(IServiceProvider serviceProvider)
        => this.serviceProvider = serviceProvider;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
       
        var context = scope.ServiceProvider.GetRequiredService<AuthorizationDbContext>();
        await context.Database.EnsureCreatedAsync(); //Create the database model if it doesn't exist

        var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();

        if (await manager.FindByClientIdAsync("consoleApp", cancellationToken) is null)
        {
            await manager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = "consoleApp",
                ClientSecret = "ee6af13a-5d04-4045-9687-73e1a796a824",
                DisplayName = "My Console Application",
                Permissions =
                {
                    OpenIddictConstants.Permissions.Endpoints.Token,
                    OpenIddictConstants.Permissions.GrantTypes.ClientCredentials,
                    OpenIddictConstants.Permissions.Prefixes.Scope + "api"
                }
            }, cancellationToken);
        }

        if (await manager.FindByClientIdAsync("webApp", cancellationToken) is null)
        {
            await manager.CreateAsync(new OpenIddictApplicationDescriptor
            {
                ClientId = "webApp", 
                ClientSecret = "44122978-f1e7-4e53-b884-07d69818344e",
                DisplayName = "Web Application",
                RedirectUris = { new Uri("https://oauth.pstmn.io/v1/callback") },
                Permissions =
                {
                    OpenIddictConstants.Permissions.Endpoints.Authorization,
                    OpenIddictConstants.Permissions.Endpoints.Token,
                    OpenIddictConstants.Permissions.GrantTypes.AuthorizationCode,
                    OpenIddictConstants.Permissions.GrantTypes.RefreshToken,                    

                    OpenIddictConstants.Permissions.Prefixes.Scope + "api",

                    OpenIddictConstants.Permissions.ResponseTypes.Code
                }
            }, cancellationToken);
        }       
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}