using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

    [HttpGet("{id}")]
    public async Task<ActionResult<ShopOwnerDTO>> GetById(Guid id)
    {
        var shopOwner = await _shopOwnerManager.GetByIdAsync(id);
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
        var createdShopOwner = await _shopOwnerManager.AddAsync(shopOwnerDto);
        return CreatedAtAction(nameof(GetById), new { id = createdShopOwner.Id }, createdShopOwner);
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