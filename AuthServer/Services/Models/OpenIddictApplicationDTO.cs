using System.Globalization;
using System.Text.Json;

namespace AuthServer.Services.Models;

public class OpenIddictApplicationDTO
{    
    public Guid Id { get; set; }
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? ConsentType { get; set; }
    public string? DisplayName { get; set; }
    public Dictionary<CultureInfo, string>? DisplayNames { get; set; }
    public HashSet<string>? Permissions { get; set; }
    public HashSet<Uri>? PostLogoutRedirectUris { get; set; }
    public Dictionary<string, JsonElement>? Properties { get; set; }
    public HashSet<Uri>? RedirectUris { get; set; }
    public HashSet<string>? Requirements { get; set; }
    public string? Type { get; set; }
}