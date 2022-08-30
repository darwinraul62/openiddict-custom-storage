using AuthServer.Services.Models;

namespace AuthServer.Services;

public interface ITokenService
{
    Task<OpenIddictTokenDTO?> FindByIdAsync(string id);
    Task<OpenIddictTokenDTO?> FindByReferenceIdAsync(string referenceId);
    Task<IEnumerable<OpenIddictTokenDTO>?> FindByAuthorizationIdAsync(string authorizationId);
    Task<OpenIddictTokenDTO?> CreateAsync(OpenIddictTokenDTO token);
    Task UpdateAsync(OpenIddictTokenDTO token);    
}