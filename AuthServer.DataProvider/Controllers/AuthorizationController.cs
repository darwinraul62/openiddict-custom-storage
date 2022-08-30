using System.ComponentModel.DataAnnotations;
using AuthServer.DataProvider.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.EntityFrameworkCore.Models;

namespace AuthServer.DataProvider.Controllers;

[Route("authorizations")]
public class AuthorizationTicketController : Controller
{
    private readonly IOpenIddictAuthorizationStore<OpenIddictEntityFrameworkCoreAuthorization> authorizationStore;
    private readonly IMapper mapper;

    public AuthorizationTicketController(
        IOpenIddictAuthorizationStoreResolver authorizationStoreResolver, 
        IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(authorizationStoreResolver);
        ArgumentNullException.ThrowIfNull(mapper);

        this.authorizationStore = authorizationStoreResolver.Get<OpenIddictEntityFrameworkCoreAuthorization>();
        this.mapper = mapper;
    }
   
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingleAsync([FromRoute, Required] Guid id)
    {
        var model = await authorizationStore.FindByIdAsync(id.ToString(), default);

        if(model == null)
            return NotFound();

        var dto = mapper.Map<OpenIddictAuthorizationDTO>(model);

        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody, Required] OpenIddictAuthorizationDTO authorizationDTO)
    {
        var modelToSave = mapper.Map<OpenIddictEntityFrameworkCoreAuthorization>(authorizationDTO);        
        await authorizationStore.CreateAsync(modelToSave, default);        
    
        authorizationDTO.Id = Guid.Parse(modelToSave.Id ?? throw new InvalidOperationException());
        
        return Ok(authorizationDTO);
    }
}