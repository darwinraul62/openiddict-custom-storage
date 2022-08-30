using System.Collections.Immutable;
using System.Globalization;
using System.Text.Json;
using AuthServer.Services;
using AuthServer.Services.Models;

namespace AuthServer.Repositories;

public class OpenIddictApplicationStore : OpenIddict.Abstractions.IOpenIddictApplicationStore<OpenIddictApplicationDTO>
{
    private IApplicationService applicationService;
    public OpenIddictApplicationStore(IApplicationService applicationService)
    {
        this.applicationService = applicationService;
    }

    public ValueTask<long> CountAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<long> CountAsync<TResult>(Func<IQueryable<OpenIddictApplicationDTO>, IQueryable<TResult>> query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask CreateAsync(OpenIddictApplicationDTO application, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask DeleteAsync(OpenIddictApplicationDTO application, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<OpenIddictApplicationDTO?> FindByClientIdAsync(string identifier, CancellationToken cancellationToken)
    {
        return new(applicationService.FindByIdAsync(identifier));
    }

    public ValueTask<OpenIddictApplicationDTO?> FindByIdAsync(string identifier, CancellationToken cancellationToken)
    {
        return new(applicationService.FindByIdAsync(identifier));
    }

    public IAsyncEnumerable<OpenIddictApplicationDTO> FindByPostLogoutRedirectUriAsync(string address, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<OpenIddictApplicationDTO> FindByRedirectUriAsync(string address, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<TResult> GetAsync<TState, TResult>(Func<IQueryable<OpenIddictApplicationDTO>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<string?> GetClientIdAsync(OpenIddictApplicationDTO application, CancellationToken cancellationToken)
    {
        return new(application.ClientId);
    }

    public ValueTask<string?> GetClientSecretAsync(OpenIddictApplicationDTO application, CancellationToken cancellationToken)
    {
        return new(application.ClientSecret);
    }

    public ValueTask<string?> GetClientTypeAsync(OpenIddictApplicationDTO application, CancellationToken cancellationToken)
    {
        return new(application.Type);
    }

    public ValueTask<string?> GetConsentTypeAsync(OpenIddictApplicationDTO application, CancellationToken cancellationToken)
    {
        return new(application.ConsentType);
    }

    public ValueTask<string?> GetDisplayNameAsync(OpenIddictApplicationDTO application, CancellationToken cancellationToken)
    {
        return new(application.DisplayName);
    }

    public ValueTask<ImmutableDictionary<CultureInfo, string>> GetDisplayNamesAsync(OpenIddictApplicationDTO application, CancellationToken cancellationToken)
    {
        return new(application?.DisplayNames?.ToImmutableDictionary() ?? ImmutableDictionary<CultureInfo, string>.Empty);
    }

    public ValueTask<string?> GetIdAsync(OpenIddictApplicationDTO application, CancellationToken cancellationToken)
    {
        return new(application.Id.ToString());
    }

    public ValueTask<ImmutableArray<string>> GetPermissionsAsync(OpenIddictApplicationDTO application, CancellationToken cancellationToken)
    {        
        return new(application.Permissions?.ToImmutableArray() ?? ImmutableArray.Create<string>() );
    }

    public ValueTask<ImmutableArray<string>> GetPostLogoutRedirectUrisAsync(OpenIddictApplicationDTO application, CancellationToken cancellationToken)
    {
        return new(application?.PostLogoutRedirectUris?.Select(p=>p.AbsoluteUri).ToImmutableArray() ?? ImmutableArray.Create<string>());
    }

    public ValueTask<ImmutableDictionary<string, JsonElement>> GetPropertiesAsync(OpenIddictApplicationDTO application, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ImmutableArray<string>> GetRedirectUrisAsync(OpenIddictApplicationDTO application, CancellationToken cancellationToken)
    {
        return new(application.RedirectUris?.Select(p => p.AbsoluteUri).ToImmutableArray() ?? ImmutableArray.Create<string>());
    }

    public ValueTask<ImmutableArray<string>> GetRequirementsAsync(OpenIddictApplicationDTO application, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<OpenIddictApplicationDTO> InstantiateAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<OpenIddictApplicationDTO> ListAsync(int? count, int? offset, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<TResult> ListAsync<TState, TResult>(Func<IQueryable<OpenIddictApplicationDTO>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetClientIdAsync(OpenIddictApplicationDTO application, string? identifier, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetClientSecretAsync(OpenIddictApplicationDTO application, string? secret, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetClientTypeAsync(OpenIddictApplicationDTO application, string? type, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetConsentTypeAsync(OpenIddictApplicationDTO application, string? type, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetDisplayNameAsync(OpenIddictApplicationDTO application, string? name, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetDisplayNamesAsync(OpenIddictApplicationDTO application, ImmutableDictionary<CultureInfo, string> names, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetPermissionsAsync(OpenIddictApplicationDTO application, ImmutableArray<string> permissions, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetPostLogoutRedirectUrisAsync(OpenIddictApplicationDTO application, ImmutableArray<string> addresses, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetPropertiesAsync(OpenIddictApplicationDTO application, ImmutableDictionary<string, JsonElement> properties, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetRedirectUrisAsync(OpenIddictApplicationDTO application, ImmutableArray<string> addresses, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetRequirementsAsync(OpenIddictApplicationDTO application, ImmutableArray<string> requirements, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask UpdateAsync(OpenIddictApplicationDTO application, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}