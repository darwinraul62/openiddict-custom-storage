using System.ComponentModel.DataAnnotations;
using AuthServer.DataProvider.Infrastructure;
using AuthServer.DataProvider.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.EntityFrameworkCore;
using OpenIddict.EntityFrameworkCore.Models;

namespace AuthServer.DataProvider.Controllers;

[Route("applications")]
public class ApplicationController : Controller
{
    private IMapper mapper;
    private IOpenIddictApplicationStore<OpenIddictEntityFrameworkCoreApplication> applicationStore;

    public ApplicationController(IOpenIddictApplicationStoreResolver applicationStoreResolver, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(applicationStoreResolver);
        ArgumentNullException.ThrowIfNull(mapper);
        this.applicationStore = applicationStoreResolver.Get<OpenIddictEntityFrameworkCoreApplication>();
        this.mapper = mapper;
    }    

    // <summary>
    // Search By Id or ClientId
    // </summary>
    // <param name="id">Client Id or internal Id</param>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingleAsync([FromRoute, Required] string id)
    {
        object? model = null;
        if(Guid.TryParse(id.ToString(), out Guid applicationId))
            model = await applicationStore.FindByIdAsync(id.ToString(), CancellationToken.None);
        else 
            model = await applicationStore.FindByClientIdAsync(id.ToString(), CancellationToken.None);

        if(model == null)
            return NotFound();

        var dto = mapper.Map<OpenIddictApplicationDTO>(model);

        return Ok(dto);
    }
}