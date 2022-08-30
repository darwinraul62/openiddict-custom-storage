using AuthServer.Services.Models;

namespace AuthServer.Services;

public interface IApplicationService
{    
    Task<OpenIddictApplicationDTO?> FindByIdAsync(string id);
}