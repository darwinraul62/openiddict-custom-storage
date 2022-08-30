using System.Text.Json;

namespace AuthServer.DataProvider.Models;

public class OpenIddictTokenDTO
{
    public Guid Id { get; set; }    
    public string? ApplicationId { get; set; }
    public string? AuthorizationId { get; set; }
    public DateTimeOffset? CreationDate { get; set; }
    public DateTimeOffset? ExpirationDate { get; set; }
    public string? Payload { get; set; }    
    public Dictionary<string, JsonElement>? Properties { get; set; }
    public DateTimeOffset? RedemptionDate { get; set; }
    public string? ReferenceId { get; set; }
    public string? Status { get; set; }
    public string? Subject { get; set; }
    public string? Type { get; set; }
}