using AuthServer.DataProvider.Models;
using AutoMapper;
using OpenIddict.Abstractions;
using OpenIddict.EntityFrameworkCore.Models;

namespace Rp3.AuthServer.DataProvider.Infrastructure.MappingProfiles;

public class OpenIddictAuthorizationProfile : Profile
{
    public OpenIddictAuthorizationProfile()
    {        
        CreateMap<OpenIddictAuthorizationDescriptor, OpenIddictAuthorizationDTO>().ReverseMap();     

        CreateMap<OpenIddictEntityFrameworkCoreAuthorization, OpenIddictAuthorizationDTO>()
            .ConvertUsing<OpenIddictEntityFrameworkCoreAuthorizationToDTOConverter>();

        CreateMap<OpenIddictAuthorizationDTO,OpenIddictEntityFrameworkCoreAuthorization>()
            .ConvertUsing<OpenIddictAuthorizationDTOToEntityFrameworkCoreConverter>();   
    }
}

public class OpenIddictEntityFrameworkCoreAuthorizationToDTOConverter : ITypeConverter<OpenIddictEntityFrameworkCoreAuthorization, OpenIddictAuthorizationDTO>
{
    private readonly IOpenIddictAuthorizationManager authorizationManager;
    private readonly IMapper mapper;

    public OpenIddictEntityFrameworkCoreAuthorizationToDTOConverter(IOpenIddictAuthorizationManager authorizationManager, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(authorizationManager);
        ArgumentNullException.ThrowIfNull(mapper);

        this.authorizationManager = authorizationManager;
        this.mapper = mapper;
    }

    public OpenIddictAuthorizationDTO Convert(OpenIddictEntityFrameworkCoreAuthorization source, OpenIddictAuthorizationDTO destination, ResolutionContext context)
    {
        var descriptor = new OpenIddictAuthorizationDescriptor();
        //execute populateasync as syncronous
        authorizationManager.PopulateAsync(descriptor, source).GetAwaiter().GetResult();
        if(destination == null)
            destination = new OpenIddictAuthorizationDTO();
        //use before mapping configuration        
        mapper.Map(descriptor, destination);
        destination.Id = Guid.Parse(source.Id ?? throw new InvalidOperationException());
        
        return destination;
    }
}

public class OpenIddictAuthorizationDTOToEntityFrameworkCoreConverter : ITypeConverter<OpenIddictAuthorizationDTO, OpenIddictEntityFrameworkCoreAuthorization>
{
    private readonly IOpenIddictAuthorizationManager authorizationManager;
    private readonly IMapper mapper;

    public OpenIddictAuthorizationDTOToEntityFrameworkCoreConverter(
        IOpenIddictAuthorizationManager authorizationManager, 
        IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(authorizationManager);
        ArgumentNullException.ThrowIfNull(mapper);

        this.authorizationManager = authorizationManager;
        this.mapper = mapper;
    }

    public OpenIddictEntityFrameworkCoreAuthorization Convert(OpenIddictAuthorizationDTO source, OpenIddictEntityFrameworkCoreAuthorization destination, ResolutionContext context)
    {
        OpenIddictAuthorizationDescriptor descriptor = new OpenIddictAuthorizationDescriptor();
        descriptor = mapper.Map<OpenIddictAuthorizationDescriptor>(source);
        
        if(destination == null)
            destination = new OpenIddictEntityFrameworkCoreAuthorization();
        //execute populateasync as syncronous
        authorizationManager.PopulateAsync(destination, descriptor).GetAwaiter().GetResult();
             
        return destination;
    }
}