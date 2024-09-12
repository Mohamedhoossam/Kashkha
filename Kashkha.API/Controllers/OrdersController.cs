using Kashkha.BL;
using Kashkha.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kashkha.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrdersController : ControllerBase
	{
		private readonly IOrderManager _orderManager;

		public OrdersController(IOrderManager orderManager)
		{
			_orderManager = orderManager;
		}
		[HttpPost]
		public async Task<ActionResult<Order>> CreateOrder([FromBody] OrderDto orderDto)
		{

			Address address = new Address()
			{
				City = orderDto?.AddressShipping.Ciry,
				Country = orderDto.AddressShipping.Country,
				Name = orderDto.AddressShipping.Name,
				Street = orderDto.AddressShipping.Street
			};
			var order = await _orderManager.CreateOrderAsync(orderDto.UserId, orderDto.CartId, address);

			if (order is null) return BadRequest();

			return Ok(order);
		}
		[HttpGet("{id:int}")]
		public ActionResult<Order> GetOrder(int id)
		{
			var orders =  _orderManager.GetOrdersForUserAsync(id);
			if(orders?.Count() <0)
			{
				return NotFound();
			}
			return Ok(orders);
		}

		[HttpGet("OrderById")]
		public  ActionResult<Order> GetOrderById([FromQuery]int userId , [FromQuery] int OrderId)
		{
			var orders =  _orderManager.GetOrderByIDForUserAsync(userId, OrderId);
			if (orders is null)
			{
				return NotFound();
			}
			return Ok(orders);

		}



	}
}
