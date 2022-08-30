using AuthServer.DataProvider.Models;
using AutoMapper;
using OpenIddict.Abstractions;
using OpenIddict.EntityFrameworkCore.Models;

namespace AuthServer.DataProvider.Infrastructure.MappingProfiles;

public class OpenIddictTokenProfile : Profile
{
    public OpenIddictTokenProfile()
    {
        CreateMap<OpenIddictTokenDescriptor, OpenIddictTokenDTO>().ReverseMap();

        CreateMap<OpenIddictEntityFrameworkCoreToken, OpenIddictTokenDTO>()
            .ConvertUsing<OpenIddictEntityFrameworkCoreTokenToDTOConverter>();

        CreateMap<OpenIddictTokenDTO,OpenIddictEntityFrameworkCoreToken>()
            .ConvertUsing<OpenIddictTokenDTOToEntityFrameworkCoreConverter>();
    }
}

public class OpenIddictEntityFrameworkCoreTokenToDTOConverter : ITypeConverter<OpenIddictEntityFrameworkCoreToken, OpenIddictTokenDTO>
{
    private readonly IOpenIddictTokenManager tokenManager;
    private readonly IMapper mapper;

    public OpenIddictEntityFrameworkCoreTokenToDTOConverter(IOpenIddictTokenManager tokenManager, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(tokenManager);
        ArgumentNullException.ThrowIfNull(mapper);

        this.tokenManager = tokenManager;
        this.mapper = mapper;
    }

    public OpenIddictTokenDTO Convert(OpenIddictEntityFrameworkCoreToken source, OpenIddictTokenDTO destination, ResolutionContext context)
    {
        OpenIddictTokenDescriptor descriptor = new OpenIddictTokenDescriptor();
        //execute populateasync as syncronous
        tokenManager.PopulateAsync(descriptor, source).GetAwaiter().GetResult();
        //use before mapping configuration
        if(destination == null)
            destination = new OpenIddictTokenDTO();

        mapper.Map(descriptor, destination);
        destination.Id = Guid.Parse(source.Id ?? throw new InvalidOperationException());
        return destination;
    }
}


public class OpenIddictTokenDTOToEntityFrameworkCoreConverter : ITypeConverter<OpenIddictTokenDTO, OpenIddictEntityFrameworkCoreToken>
{
    private readonly IOpenIddictTokenManager tokenManager;
    private readonly IMapper mapper;

    public OpenIddictTokenDTOToEntityFrameworkCoreConverter(IOpenIddictTokenManager tokenManager, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(tokenManager);
        ArgumentNullException.ThrowIfNull(mapper);

        this.tokenManager = tokenManager;
        this.mapper = mapper;
    }

    public OpenIddictEntityFrameworkCoreToken Convert(OpenIddictTokenDTO source, OpenIddictEntityFrameworkCoreToken destination, ResolutionContext context)
    {
        OpenIddictTokenDescriptor descriptor = new OpenIddictTokenDescriptor();
        descriptor = mapper.Map<OpenIddictTokenDescriptor>(source);
        
        if(destination == null)
            destination = new OpenIddictEntityFrameworkCoreToken();

        //execute populateasync as syncronous
        tokenManager.PopulateAsync(destination, descriptor).GetAwaiter().GetResult();
        
        return destination;
    }
}