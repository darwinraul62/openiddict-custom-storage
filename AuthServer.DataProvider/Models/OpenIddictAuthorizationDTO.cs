using System.Text.Json;

namespace AuthServer.DataProvider.Models;

public class OpenIddictAuthorizationDTO
{
    public Guid Id { get; set; }
    public string? ApplicationId { get; set; }
    public DateTimeOffset? CreationDate { get; set; }    
    public Dictionary<string, JsonElement>? Properties { get; set; }
    public HashSet<string>? Scopes { get; set; }
    public string? Status { get; set; }
    public string? Subject { get; set; }
    public string? Type { get; set; }
}