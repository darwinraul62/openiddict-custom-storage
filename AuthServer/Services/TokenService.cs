using System.Net;
using System.Text.Json;
using AuthServer.Services.Models;

namespace AuthServer.Services;

public class TokenService : ITokenService
{    
    private string GetByIdUrl(string id) => $"tokens/{id}";    
    private string GetByReferenceUrl(string referenceId) => $"tokens?referenceId={WebUtility.UrlEncode(referenceId)}";
    private string GetByAuthorizationUrl(string authorizationId) => $"tokens?authorizationId={WebUtility.UrlEncode(authorizationId)}";
    private string CreateTokenUrl() => "tokens";
    private string UpdateTokenUrl(Guid id) => $"tokens/{id}";

    private readonly HttpClient httpClient;
    public TokenService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<OpenIddictTokenDTO?> FindByIdAsync(string id)
    {
        string response = await httpClient.GetStringAsync(GetByIdUrl(id));        
        return System.Text.Json.JsonSerializer.Deserialize<OpenIddictTokenDTO>(response, DefaultOptions);
    }
    public async Task<OpenIddictTokenDTO?> FindByReferenceIdAsync(string referenceId)
    {
        string response = await httpClient.GetStringAsync(GetByReferenceUrl(referenceId));
        
        var model = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<OpenIddictTokenDTO>>(response, DefaultOptions); 
        if(model!=null &&  model.Any())
            return model.First();
        
        return null;
    }
    public async Task<IEnumerable<OpenIddictTokenDTO>?> FindByAuthorizationIdAsync(string authorizationId)
    {
        string response = await httpClient.GetStringAsync(GetByAuthorizationUrl(authorizationId));        
        return System.Text.Json.JsonSerializer.Deserialize<IEnumerable<OpenIddictTokenDTO>>(response, DefaultOptions);         
    }
    public async Task<OpenIddictTokenDTO?> CreateAsync(OpenIddictTokenDTO token)
    {
        var response = await httpClient.PostAsJsonAsync(CreateTokenUrl(), token);
        
        response.EnsureSuccessStatusCode();

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<OpenIddictTokenDTO>();
        }
        return null;
    }
    public async Task UpdateAsync(OpenIddictTokenDTO token)
    {
        var response = await httpClient.PutAsJsonAsync(UpdateTokenUrl(token.Id), token);
        
        response.EnsureSuccessStatusCode();
    }
    private readonly JsonSerializerOptions DefaultOptions = new System.Text.Json.JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
        };
}