using System.ComponentModel.DataAnnotations;
using AuthServer.DataProvider.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.EntityFrameworkCore.Models;

namespace AuthServer.DataProvider.Controllers;

[Route("tokens")]
public class TokenController : Controller
{
    private IMapper mapper;
    private IOpenIddictTokenStore<OpenIddictEntityFrameworkCoreToken> tokenStore;

    public TokenController(
        IMapper mapper,
        IOpenIddictTokenStoreResolver tokenStoreResolver)
    {
        ArgumentNullException.ThrowIfNull(tokenStoreResolver);
        ArgumentNullException.ThrowIfNull(mapper);        
        this.tokenStore = tokenStoreResolver.Get<OpenIddictEntityFrameworkCoreToken>();;
        this.mapper = mapper;
    }    

    [HttpGet]
    public async Task<IActionResult> GetAsync(
        [FromQuery]string? referenceId = null,        
        [FromQuery]string? authorizationId = null) 
    {
        List<OpenIddictTokenDTO> resultDTO = new List<OpenIddictTokenDTO>();     
        
        if(referenceId != null)
        {
            var model = await tokenStore.FindByReferenceIdAsync(referenceId, default);
            if(model != null)
                resultDTO.Add(mapper.Map<OpenIddictTokenDTO>(model));
        }
        else if(authorizationId != null)
        {
            var model = tokenStore.FindByAuthorizationIdAsync(authorizationId, default);
            await foreach (var item in model)                
                resultDTO.Add(mapper.Map<OpenIddictTokenDTO>(item));
        }
        
        return Ok(resultDTO);        
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetSingleIdAsync(
        [FromRoute, Required]Guid id) 
    {
        var model = await tokenStore.FindByIdAsync(id.ToString(), default);
        
        if(model == null)
            return NotFound();

        var dto = mapper.Map<OpenIddictTokenDTO>(model);

        return Ok(dto);
    }

    [HttpPost]    
    public async Task<IActionResult> CreateAsync([FromBody, Required] OpenIddictTokenDTO tokenDTO)
    {
        var tokenToSave = mapper.Map<OpenIddictEntityFrameworkCoreToken>(tokenDTO);        
        await tokenStore.CreateAsync(tokenToSave, default);        
    
        tokenDTO.Id = Guid.Parse(tokenToSave.Id ?? throw new InvalidOperationException());
        
        return Ok(tokenDTO);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAsync(
        [FromRoute, Required] Guid id,
        [FromBody, Required] OpenIddictTokenDTO tokenDTO)
    {
        var tokenToSaveModel = await tokenStore.FindByIdAsync(id.ToString(), default);
        
        if (tokenToSaveModel == null)
            return NotFound();

        mapper.Map(tokenDTO, tokenToSaveModel);        
        await tokenStore.UpdateAsync(tokenToSaveModel, default);
        
        return NoContent();
    }
}