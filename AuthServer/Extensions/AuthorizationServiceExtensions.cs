using AuthServer.Repositories;
using AuthServer.Services.Models;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenIddict.Core;

namespace Microsoft.Extensions.Hosting;

public static class AuthorizationServiceExtensions
{
    public static void AddAutorizationService(this IServiceCollection services)
    {
        services.AddOpenIddict()

       // Register the OpenIddict core components.
       .AddCore(options =>
       {            
            options.Services.Configure<OpenIddictCoreOptions>(options =>
            {
                // Entity Models               
                options.DefaultApplicationType = typeof(OpenIddictApplicationDTO);
                options.DefaultAuthorizationType = typeof(OpenIddictAuthorizationDTO);                
                options.DefaultTokenType = typeof(OpenIddictTokenDTO);
                options.DefaultScopeType = typeof(OpenIddictScopeDTO);
            });

           // Configure OpenIddict to use custom storage                        
            options.AddApplicationStore<OpenIddictApplicationStore>();
            options.AddAuthorizationStore<OpenIddictAuthorizationStore>();
            options.AddTokenStore<OpenIddictTokenStore>();
            options.AddScopeStore<OpenIddictScopeStore>();           

            // Register the Stores as scoped services
            options.Services.TryAddScoped(typeof(OpenIddictApplicationStore));
            options.Services.TryAddScoped(typeof(OpenIddictAuthorizationStore));
            options.Services.TryAddScoped(typeof(OpenIddictTokenStore));
            options.Services.TryAddScoped(typeof(OpenIddictScopeStore));
       })
       // Register the OpenIddict server components.
       .AddServer(options =>
       {
           options
               .AllowClientCredentialsFlow()
               .AllowAuthorizationCodeFlow()
               .RequireProofKeyForCodeExchange()
               .AllowRefreshTokenFlow();

           options
               .SetTokenEndpointUris("/oauth/token")
               .SetAuthorizationEndpointUris("/oauth/authorize")
               .SetUserinfoEndpointUris("/oauth/userinfo");

           // Encryption and signing of tokens
           options.AddEphemeralEncryptionKey()
                  .AddEphemeralSigningKey();

           options.DisableAccessTokenEncryption();
           // Register scopes (permissions)
           options.RegisterScopes("api","openid","offline_access");

           // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
           options
               .UseAspNetCore()
               .EnableTokenEndpointPassthrough()
               .EnableAuthorizationEndpointPassthrough()
               .EnableUserinfoEndpointPassthrough();
       });
    }
}
