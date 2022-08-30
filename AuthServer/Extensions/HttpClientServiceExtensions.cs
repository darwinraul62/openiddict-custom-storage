using System.Net.Http.Headers;
using AuthServer.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class HttpClientServiceExtensions
{
    public static IServiceCollection AddHttpClientServices(this IServiceCollection services, IConfiguration configuration)
    {               
        string authorizationServer = configuration["AuthorizationServerDataProviderUrl"];

        services.AddHttpClient<IApplicationService, ApplicationService>(client =>
        {            
            client.BaseAddress = new Uri(authorizationServer);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });

        services.AddHttpClient<ITokenService, TokenService>(client =>
        {            
            client.BaseAddress = new Uri(authorizationServer);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });

        services.AddHttpClient<IAuthorizationService, AuthorizationService>(client =>
        {            
            client.BaseAddress = new Uri(authorizationServer);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        });
        
        return services;
    }
}