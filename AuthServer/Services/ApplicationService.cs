using System.Text.Json;
using AuthServer.Services.Models;
using OpenIddict.Abstractions;

namespace AuthServer.Services;

public class ApplicationService : IApplicationService
{       
    private string GetApplicationUrl(string id) => $"applications/{id}";

    private readonly HttpClient httpClient;

    public ApplicationService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<OpenIddictApplicationDTO?> FindByIdAsync(string id)
    {
        string response = await httpClient.GetStringAsync(GetApplicationUrl(id));

        var model = System.Text.Json.JsonSerializer.Deserialize<OpenIddictApplicationDTO>(response, DefaultOptions);

        return model;
    }
    private readonly JsonSerializerOptions DefaultOptions = new System.Text.Json.JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DictionaryKeyPolicy = JsonNamingPolicy.CamelCase
        };
}