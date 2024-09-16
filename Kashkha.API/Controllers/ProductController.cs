using Kashkha.BL;
using Kashkha.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kashkha.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductManager _productManager;

		public ProductController(IProductManager productManager)
		{
			_productManager = productManager;
		}

		[HttpGet]

		public ActionResult GetAll([FromQuery] string? categoryName)
		{
		//
			return Ok(_productManager.GetAll(categoryName));

		}


		[HttpGet("{id:int}")]
		public ActionResult GetProduct([FromRoute] int id)
		{


			return Ok(new { message = "success", Data = _productManager.Get(id) });
		}

		[HttpPost]
		[Authorize(Roles ="Shop Owner")]
		public ActionResult PostProduct([FromForm] AddProductDto productDto)
		{
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			_productManager.Add(productDto,userId);
			return Ok(new { message = "success" });
		}

		[HttpDelete("{id:int}")]
		[Authorize(Roles = "Shop Owner")]
		public ActionResult DeleteProduct([FromRoute] int id)
		{
			if (!_productManager.isFound(id))
			{
				return NotFound("this product not fount");

			}
			var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			var result = _productManager.Delete(_productManager.GetWithOutUrl(id), userId);
			if (result is null)
				return BadRequest("you not have access to this data");
			return NoContent();
		}

		[HttpPut]
		[Authorize(Roles = "Shop Owner")]
		public ActionResult UpdateProduct([FromForm] UpdateProductDto updateProduct)
		{
			_productManager.Update(updateProduct);
			return NoContent();

		}


	}
}
