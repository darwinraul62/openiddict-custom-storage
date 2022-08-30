using AuthServer.DataProvider.Models;
using AutoMapper;
using OpenIddict.Abstractions;
using OpenIddict.EntityFrameworkCore.Models;

namespace AuthServer.DataProvider.Infrastructure.MappingProfiles;

public class OpenIddictApplicationProfile : Profile
{
    public OpenIddictApplicationProfile()
    {        
        CreateMap<OpenIddictApplicationDescriptor, OpenIddictApplicationDTO>();
        CreateMap<OpenIddictEntityFrameworkCoreApplication, OpenIddictApplicationDTO>().ConvertUsing<OpenIddictEntityFrameworkCoreApplicationToDTOConverter>();
    }
}

public class OpenIddictEntityFrameworkCoreApplicationToDTOConverter : ITypeConverter<OpenIddictEntityFrameworkCoreApplication, OpenIddictApplicationDTO>
{
    private readonly IOpenIddictApplicationManager applicationManager;
    private readonly IMapper mapper;

    public OpenIddictEntityFrameworkCoreApplicationToDTOConverter(IOpenIddictApplicationManager applicationManager, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(applicationManager);
        ArgumentNullException.ThrowIfNull(mapper);

        this.applicationManager = applicationManager;
        this.mapper = mapper;
    }

    public OpenIddictApplicationDTO Convert(OpenIddictEntityFrameworkCoreApplication source, OpenIddictApplicationDTO destination, ResolutionContext context)
    {
        var descriptor = new OpenIddictApplicationDescriptor();
        //execute populateasync as syncronous
        applicationManager.PopulateAsync(descriptor, source).GetAwaiter().GetResult();
        if(destination == null)
            destination = new OpenIddictApplicationDTO();
        //use before mapping configuration
        mapper.Map(descriptor, destination);
        destination.Id = Guid.Parse(source.Id ?? throw new InvalidOperationException());
        
        return destination;
    }
}