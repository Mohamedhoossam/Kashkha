using Kashkha.BL.Managers.CartManager;
using Kashkha.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kashkha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartManager cartManager;

        public CartController(ICartManager _cartManager)
        {
            cartManager = _cartManager;
        }


        [HttpGet]
        public async Task<ActionResult<Cart>> GetCart(string Id)
        {
            var cart = await cartManager.GetCartAsync(Id);
            if (cart is null) return new Cart(Id);
            return Ok(cart);

        }

        [HttpPost]
        //Update or Create Cart
        public async Task<ActionResult<Cart>> UpdateOrCreateCart(Cart cart)
        {
            var UpdatedOrDeletedCart = await cartManager.UpdateCart(cart);
            if (UpdatedOrDeletedCart is null) return BadRequest();
            return Ok(UpdatedOrDeletedCart);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCart(string id)
        {
            return await cartManager.DeleteCart(id);

        }

        // [HttpPost("AddToCart")]
        // public async Task<ActionResult<Cart>> AddToCart(string cartId, string productId, int quantity)
        // {
        //     var cart = await cartManager.AddToCart(cartId, productId, quantity);
        //     if (cart is null) return BadRequest();
        //     return Ok(cart);
        // }

    }
}
