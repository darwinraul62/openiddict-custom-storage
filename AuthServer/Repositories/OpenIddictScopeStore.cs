using System.Collections.Immutable;
using System.Globalization;
using System.Text.Json;
using AuthServer.Services.Models;

namespace AuthServer.Repositories;

public class OpenIddictScopeStore : OpenIddict.Abstractions.IOpenIddictScopeStore<OpenIddictScopeDTO>
{
    public ValueTask<long> CountAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<long> CountAsync<TResult>(Func<IQueryable<OpenIddictScopeDTO>, IQueryable<TResult>> query, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask CreateAsync(OpenIddictScopeDTO scope, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask DeleteAsync(OpenIddictScopeDTO scope, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<OpenIddictScopeDTO?> FindByIdAsync(string identifier, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<OpenIddictScopeDTO?> FindByNameAsync(string name, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<OpenIddictScopeDTO> FindByNamesAsync(ImmutableArray<string> names, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<OpenIddictScopeDTO> FindByResourceAsync(string resource, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<TResult> GetAsync<TState, TResult>(Func<IQueryable<OpenIddictScopeDTO>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<string?> GetDescriptionAsync(OpenIddictScopeDTO scope, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ImmutableDictionary<CultureInfo, string>> GetDescriptionsAsync(OpenIddictScopeDTO scope, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<string?> GetDisplayNameAsync(OpenIddictScopeDTO scope, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ImmutableDictionary<CultureInfo, string>> GetDisplayNamesAsync(OpenIddictScopeDTO scope, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<string?> GetIdAsync(OpenIddictScopeDTO scope, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<string?> GetNameAsync(OpenIddictScopeDTO scope, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ImmutableDictionary<string, JsonElement>> GetPropertiesAsync(OpenIddictScopeDTO scope, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<ImmutableArray<string>> GetResourcesAsync(OpenIddictScopeDTO scope, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask<OpenIddictScopeDTO> InstantiateAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<OpenIddictScopeDTO> ListAsync(int? count, int? offset, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public IAsyncEnumerable<TResult> ListAsync<TState, TResult>(Func<IQueryable<OpenIddictScopeDTO>, TState, IQueryable<TResult>> query, TState state, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetDescriptionAsync(OpenIddictScopeDTO scope, string? description, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetDescriptionsAsync(OpenIddictScopeDTO scope, ImmutableDictionary<CultureInfo, string> descriptions, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetDisplayNameAsync(OpenIddictScopeDTO scope, string? name, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetDisplayNamesAsync(OpenIddictScopeDTO scope, ImmutableDictionary<CultureInfo, string> names, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetNameAsync(OpenIddictScopeDTO scope, string? name, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetPropertiesAsync(OpenIddictScopeDTO scope, ImmutableDictionary<string, JsonElement> properties, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask SetResourcesAsync(OpenIddictScopeDTO scope, ImmutableArray<string> resources, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ValueTask UpdateAsync(OpenIddictScopeDTO scope, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

