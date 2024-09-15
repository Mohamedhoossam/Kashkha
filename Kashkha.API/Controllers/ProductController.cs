﻿using Kashkha.BL;
using Kashkha.DAL;
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
		
		public ActionResult PostProduct([FromForm] AddProductDto productDto)
		{

			_productManager.Add(productDto);
			return Ok(new { message = "success" });
		}

		[HttpDelete("{id:int}")]
		public ActionResult DeleteProduct([FromRoute] int id)
		{
			if (!_productManager.isFound(id))
			{
				return NotFound("this product not fount");

			}
			_productManager.Delete(_productManager.GetWithOutUrl(id));
			return NoContent();
		}

		[HttpPut]
		public ActionResult UpdateProduct([FromForm] UpdateProductDto updateProduct)
		{
			_productManager.Update(updateProduct);
			return NoContent();

		}


	}
}
