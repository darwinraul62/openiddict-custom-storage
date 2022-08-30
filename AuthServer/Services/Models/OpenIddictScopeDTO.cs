using System.Globalization;
using System.Text.Json;

namespace AuthServer.Services.Models;

public class OpenIddictScopeDTO
{
    public string? Description { get; set; }

    public Dictionary<CultureInfo, string>? Descriptions { get; set; }

    public string? DisplayName { get; set; }

    public Dictionary<CultureInfo, string>? DisplayNames { get; set; }

    public string? Name { get; set; }

    public Dictionary<string, JsonElement>? Properties { get; set; }

    public HashSet<string>? Resources { get; set; }
}