using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Text.Json;
using AuthServer.Services;
using AuthServer.Services.Models;

namespace AuthServer.Repositories;

public class OpenIddictTokenStore : OpenIddict.Abstractions.IOpenIddictTokenStore<OpenIddictTokenDTO>
{
    private ITokenService tokenService;
    public OpenIddictTokenStore(ITokenService tokenService)
    {
        this.tokenService = tokenService;
    }

    public ValueTask<long> CountAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<long> CountAsync<TResult>(Func<IQueryable<OpenIddictTokenDTO>, IQueryable<TResult>> query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async ValueTask CreateAsync(OpenIddictTokenDTO token, CancellationToken cancellationToken)
    {        
        var result = await tokenService.CreateAsync(token);        
        token.Id = result?.Id ?? Guid.Empty;
    }

    public ValueTask DeleteAsync(OpenIddictTokenDTO token, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<OpenIddictTokenDTO> FindAsync(string subject, string client, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<OpenIddictTokenDTO> FindAsync(string subject, string client, string status, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<OpenIddictTokenDTO> FindAsync(string subject, string client, string status, string type, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<OpenIddictTokenDTO> FindByApplicationIdAsync(string identifier, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async IAsyncEnumerable<OpenIddictTokenDTO> FindByAuthorizationIdAsync(string identifier, [EnumeratorCancellation]CancellationToken cancellationToken)
    {        
        var result = await tokenService.FindByAuthorizationIdAsync(identifier);
        if(result!=null)
        {
            foreach(var item in result)            
                yield return item;
        }
        else        
            yield break;                   
    }

    public ValueTask<OpenIddictTokenDTO?> FindByIdAsync(string identifier, CancellationToken cancellationToken)
    {
        return new(tokenService.FindByIdAsync(identifier));
    }

    public ValueTask<OpenIddictTokenDTO?> FindByReferenceIdAsync(string identifier, CancellationToken cancellationToken)
    {
        if(string.IsNullOrWhiteSpace(identifier))
            return default;
        
        return new(tokenService.FindByReferenceIdAsync(identifier));
    }

    public IAsyncEnumerable<OpenIddictTokenDTO> FindBySubjectAsync(string subject, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<string?> GetApplicationIdAsync(OpenIddictTokenDTO token, CancellationToken cancellationToken)
    {
        return new(token.ApplicationId);
    }

    public ValueTask<TResult> GetAsync<TState, TResult>(Func<IQueryable<OpenIddictTokenDTO>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<string?> GetAuthorizationIdAsync(OpenIddictTokenDTO token, CancellationToken cancellationToken)
    {
        return new(token.AuthorizationId);
    }

    public ValueTask<DateTimeOffset?> GetCreationDateAsync(OpenIddictTokenDTO token, CancellationToken cancellationToken)
    {
        return new(token.CreationDate);
    }

    public ValueTask<DateTimeOffset?> GetExpirationDateAsync(OpenIddictTokenDTO token, CancellationToken cancellationToken)
    {
        return new(token.ExpirationDate);
    }

    public ValueTask<string?> GetIdAsync(OpenIddictTokenDTO token, CancellationToken cancellationToken)
    {
        return new(token.Id.ToString());
    }

    public ValueTask<string?> GetPayloadAsync(OpenIddictTokenDTO token, CancellationToken cancellationToken)
    {
        return new(token.Payload);
    }

    public ValueTask<ImmutableDictionary<string, JsonElement>> GetPropertiesAsync(OpenIddictTokenDTO token, CancellationToken cancellationToken)
    {
        return new(token.Properties?.ToImmutableDictionary(p=>p.Key, p=>p.Value) ?? ImmutableDictionary<string, JsonElement>.Empty);
    }

    public ValueTask<DateTimeOffset?> GetRedemptionDateAsync(OpenIddictTokenDTO token, CancellationToken cancellationToken)
    {
        return new(token.RedemptionDate);
    }

    public ValueTask<string?> GetReferenceIdAsync(OpenIddictTokenDTO token, CancellationToken cancellationToken)
    {
        return new(token.ReferenceId);
    }

    public ValueTask<string?> GetStatusAsync(OpenIddictTokenDTO token, CancellationToken cancellationToken)
    {
        return new(token.Status);
    }

    public ValueTask<string?> GetSubjectAsync(OpenIddictTokenDTO token, CancellationToken cancellationToken)
    {
        return new(token.Subject);
    }

    public ValueTask<string?> GetTypeAsync(OpenIddictTokenDTO token, CancellationToken cancellationToken)
    {
        return new(token.Type);
    }

    public ValueTask<OpenIddictTokenDTO> InstantiateAsync(CancellationToken cancellationToken)
    {
        return new(new OpenIddictTokenDTO());
    }

    public IAsyncEnumerable<OpenIddictTokenDTO> ListAsync(int? count, int? offset, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<TResult> ListAsync<TState, TResult>(Func<IQueryable<OpenIddictTokenDTO>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask PruneAsync(DateTimeOffset threshold, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetApplicationIdAsync(OpenIddictTokenDTO token, string? identifier, CancellationToken cancellationToken)
    {
        token.ApplicationId = identifier;
        return default;
    }

    public ValueTask SetAuthorizationIdAsync(OpenIddictTokenDTO token, string? identifier, CancellationToken cancellationToken)
    {
        token.AuthorizationId = identifier;
        return default;
    }

    public ValueTask SetCreationDateAsync(OpenIddictTokenDTO token, DateTimeOffset? date, CancellationToken cancellationToken)
    {
        token.CreationDate = date;
        return default;
    }

    public ValueTask SetExpirationDateAsync(OpenIddictTokenDTO token, DateTimeOffset? date, CancellationToken cancellationToken)
    {
        token.ExpirationDate = date;
        return default;
    }

    public ValueTask SetPayloadAsync(OpenIddictTokenDTO token, string? payload, CancellationToken cancellationToken)
    {
        token.Payload = payload;
        return default;
    }

    public ValueTask SetPropertiesAsync(OpenIddictTokenDTO token, ImmutableDictionary<string, JsonElement> properties, CancellationToken cancellationToken)
    {
        token.Properties = properties.ToDictionary(p => p.Key, p => p.Value);
        return default;
    }

    public ValueTask SetRedemptionDateAsync(OpenIddictTokenDTO token, DateTimeOffset? date, CancellationToken cancellationToken)
    {
        token.RedemptionDate = date;
        return default;
    }

    public ValueTask SetReferenceIdAsync(OpenIddictTokenDTO token, string? identifier, CancellationToken cancellationToken)
    {
        token.ReferenceId = identifier;
        return default;
    }

    public ValueTask SetStatusAsync(OpenIddictTokenDTO token, string? status, CancellationToken cancellationToken)
    {
        token.Status = status;
        return default;
    }

    public ValueTask SetSubjectAsync(OpenIddictTokenDTO token, string? subject, CancellationToken cancellationToken)
    {
        token.Subject = subject;
        return default;
    }

    public ValueTask SetTypeAsync(OpenIddictTokenDTO token, string? type, CancellationToken cancellationToken)
    {
        token.Type = type;        
        return default;
    }

    public async ValueTask UpdateAsync(OpenIddictTokenDTO token, CancellationToken cancellationToken)
    {
        await tokenService.UpdateAsync(token);        
    }
}