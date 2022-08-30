using System.Collections.Immutable;
using System.Text.Json;
using AuthServer.Services;
using AuthServer.Services.Models;

namespace AuthServer.Repositories;

public class OpenIddictAuthorizationStore : OpenIddict.Abstractions.IOpenIddictAuthorizationStore<OpenIddictAuthorizationDTO>
{
    private readonly IAuthorizationService authorizationService;
    public OpenIddictAuthorizationStore(IAuthorizationService authorizationService)
    {
        this.authorizationService = authorizationService;
    }

    public ValueTask<long> CountAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<long> CountAsync<TResult>(Func<IQueryable<OpenIddictAuthorizationDTO>, IQueryable<TResult>> query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async ValueTask CreateAsync(OpenIddictAuthorizationDTO authorization, CancellationToken cancellationToken)
    {
        var result = await authorizationService.CreateAsync(authorization);
        authorization.Id = result?.Id ?? Guid.Empty;
    }

    public ValueTask DeleteAsync(OpenIddictAuthorizationDTO authorization, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<OpenIddictAuthorizationDTO> FindAsync(string subject, string client, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<OpenIddictAuthorizationDTO> FindAsync(string subject, string client, string status, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<OpenIddictAuthorizationDTO> FindAsync(string subject, string client, string status, string type, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<OpenIddictAuthorizationDTO> FindAsync(string subject, string client, string status, string type, ImmutableArray<string> scopes, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<OpenIddictAuthorizationDTO> FindByApplicationIdAsync(string identifier, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<OpenIddictAuthorizationDTO?> FindByIdAsync(string identifier, CancellationToken cancellationToken)
    {
        return new(authorizationService.FindByIdAsync(Guid.Parse(identifier)));
    }

    public IAsyncEnumerable<OpenIddictAuthorizationDTO> FindBySubjectAsync(string subject, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<string?> GetApplicationIdAsync(OpenIddictAuthorizationDTO authorization, CancellationToken cancellationToken)
    {
        return new(authorization.ApplicationId);
    }

    public ValueTask<TResult> GetAsync<TState, TResult>(Func<IQueryable<OpenIddictAuthorizationDTO>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<DateTimeOffset?> GetCreationDateAsync(OpenIddictAuthorizationDTO authorization, CancellationToken cancellationToken)
    {
        return new(authorization.CreationDate);
    }

    public ValueTask<string?> GetIdAsync(OpenIddictAuthorizationDTO authorization, CancellationToken cancellationToken)
    {
        return new(authorization.Id.ToString());
    }

    public ValueTask<ImmutableDictionary<string, JsonElement>> GetPropertiesAsync(OpenIddictAuthorizationDTO authorization, CancellationToken cancellationToken)
    {
        return new(authorization.Properties?.ToImmutableDictionary() ?? ImmutableDictionary<string, JsonElement>.Empty);
    }

    public ValueTask<ImmutableArray<string>> GetScopesAsync(OpenIddictAuthorizationDTO authorization, CancellationToken cancellationToken)
    {
        return new(authorization.Scopes?.ToImmutableArray() ?? ImmutableArray<string>.Empty);
    }

    public ValueTask<string?> GetStatusAsync(OpenIddictAuthorizationDTO authorization, CancellationToken cancellationToken)
    {
        return new(authorization.Status);
    }

    public ValueTask<string?> GetSubjectAsync(OpenIddictAuthorizationDTO authorization, CancellationToken cancellationToken)
    {
        return new(authorization.Subject);
    }

    public ValueTask<string?> GetTypeAsync(OpenIddictAuthorizationDTO authorization, CancellationToken cancellationToken)
    {
        return new(authorization.Type);
    }

    public ValueTask<OpenIddictAuthorizationDTO> InstantiateAsync(CancellationToken cancellationToken)
    {
        return new(new OpenIddictAuthorizationDTO());
    }

    public IAsyncEnumerable<OpenIddictAuthorizationDTO> ListAsync(int? count, int? offset, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<TResult> ListAsync<TState, TResult>(Func<IQueryable<OpenIddictAuthorizationDTO>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask PruneAsync(DateTimeOffset threshold, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetApplicationIdAsync(OpenIddictAuthorizationDTO authorization, string? identifier, CancellationToken cancellationToken)
    {
        authorization.ApplicationId = identifier;
        return default;
    }

    public ValueTask SetCreationDateAsync(OpenIddictAuthorizationDTO authorization, DateTimeOffset? date, CancellationToken cancellationToken)
    {
        authorization.CreationDate = date;
        return default;
    }

    public ValueTask SetPropertiesAsync(OpenIddictAuthorizationDTO authorization, ImmutableDictionary<string, JsonElement> properties, CancellationToken cancellationToken)
    {
        authorization.Properties = properties.ToDictionary(x => x.Key, x => x.Value);
        return default;
    }

    public ValueTask SetScopesAsync(OpenIddictAuthorizationDTO authorization, ImmutableArray<string> scopes, CancellationToken cancellationToken)
    {
        authorization.Scopes = scopes.ToHashSet();
        return default;
    }

    public ValueTask SetStatusAsync(OpenIddictAuthorizationDTO authorization, string? status, CancellationToken cancellationToken)
    {
        authorization.Status = status;
        return default;
    }

    public ValueTask SetSubjectAsync(OpenIddictAuthorizationDTO authorization, string? subject, CancellationToken cancellationToken)
    {
        authorization.Subject = subject;
        return default;
    }

    public ValueTask SetTypeAsync(OpenIddictAuthorizationDTO authorization, string? type, CancellationToken cancellationToken)
    {
        authorization.Type = type;
        return default;
    }

    public ValueTask UpdateAsync(OpenIddictAuthorizationDTO authorization, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}