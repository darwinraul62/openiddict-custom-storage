using AuthServer.Services.Models;

namespace AuthServer.Services;

public interface IAuthorizationService
{
    Task<OpenIddictAuthorizationDTO?> CreateAsync(OpenIddictAuthorizationDTO token);
    Task<OpenIddictAuthorizationDTO?> FindByIdAsync(Guid id);
}