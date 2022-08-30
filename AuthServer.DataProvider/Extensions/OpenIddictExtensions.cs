using AuthServer.DataProvider.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.Hosting;

public static class OpenIddictExtensions
{
    public static void AddOpenIddictStorage(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AuthorizationDbContext >(options =>
        {
            // Configure the context to use sql server database store
            options.UseSqlServer(configuration.GetConnectionString("AuthorizationServerConnection"));

            // Register the entity sets needed by OpenIddict.
            options.UseOpenIddict();
        });

        services.AddOpenIddict()

        // Register the OpenIddict core components.
        .AddCore(options =>
        {
            // Configure OpenIddict to use the Entity Framework Core Models.
            options.UseEntityFrameworkCore()
                .UseDbContext<AuthorizationDbContext >();
        });      
    }
}