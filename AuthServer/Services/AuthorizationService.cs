using System.Text.Json;
using AuthServer.Services.Models;

namespace AuthServer.Services;

public class AuthorizationService : IAuthorizationService
{        
    private string GetByIdUrl(Guid id) => $"authorizations/{id}";
    private string CreateUrl() => "authorizations";

    private readonly HttpClient httpClient;
    public AuthorizationService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }
    public async Task<OpenIddictAuthorizationDTO?> FindByIdAsync(Guid id)
    {
        string response = await httpClient.GetStringAsync(GetByIdUrl(id));        
        var model = System.Text.Json.JsonSerializer.Deserialize<OpenIddictAuthorizationDTO>(response, DefaultOptions);                 
        return model;
    }    
    public async Task<OpenIddictAuthorizationDTO?> CreateAsync(OpenIddictAuthorizationDTO token)
    {
        var response = await httpClient.PostAsJsonAsync(CreateUrl(), token);
        
        response.EnsureSuccessStatusCode();

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<OpenIddictAuthorizationDTO>();
        }
        return null;
    }
    private readonly JsonSerializerOptions DefaultOptions = new System.Text.Json.JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
        };
}