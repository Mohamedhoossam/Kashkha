using Kashkha.BL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

		public ActionResult GetAll()
		{
			return Ok(_productManager.GetAll());

		}

		[HttpPost]
		public ActionResult PostProduct([FromBody]AddProductDto productDto)
		{
		
			_productManager.Add(productDto);
			return Ok(new {message= "ok" });
		}

	}
}
