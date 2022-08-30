using Microsoft.AspNetCore.Authentication.Cookies;

namespace Microsoft.Extensions.Hosting;

public static class AuthenticationExtensions
{
    public static void AddAuthenticationService(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.LoginPath = "/account/login";
            });
    }
}