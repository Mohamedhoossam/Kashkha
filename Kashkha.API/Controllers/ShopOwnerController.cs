using Kashkha.BL.DTOs.ShopOwnerDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ShopOwnerController : ControllerBase
{
    private readonly IShopManager _shopOwnerManager;

    public ShopOwnerController(IShopManager shopOwnerManager)
    {
        _shopOwnerManager = shopOwnerManager;
    }

    [HttpGet]
    [Route("{id}")]

    public async Task<ActionResult<GetOwnerinfo>> GetById(string id)
    {
        var shopOwner = await _shopOwnerManager.GetByIdAsync(id);
        var user = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        
        if (shopOwner == null)
        {
            return NotFound();
        }
        return Ok(shopOwner);
    }

    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<ShopOwnerDTO>>> GetAll()
    // {
    //     var shopOwners = await _shopOwnerManager.GetAllAsync();
    //     return Ok(shopOwners);
    // }

    [HttpPost]
    public async Task<ActionResult<ShopOwnerDTO>> Create(ShopOwnerDTO shopOwnerDto)
    {
        var result = await _shopOwnerManager.AddAsync(shopOwnerDto);
        if (result is null)
            return BadRequest();
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, ShopOwnerDTO shopOwnerDto)
    {
        if (id != shopOwnerDto.Id)
        {
            return BadRequest();
        }
        await _shopOwnerManager.UpdateAsync(shopOwnerDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _shopOwnerManager.DeleteAsync(id);
        return NoContent();
    }
}