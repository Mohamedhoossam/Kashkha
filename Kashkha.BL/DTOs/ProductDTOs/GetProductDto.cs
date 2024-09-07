using Kashkha.DAL;
using Microsoft.AspNetCore.Http;

namespace Kashkha.API
{
	public class GetProductDto
	{

		public string ProductName { get; set; }
		public string? Description { get; set; }
		public string? Image { get; set; } 
		public decimal Price { get; set; }
		public int Quantity { get; set; }
		public int? CategoryId { get; set; }
		public Category? Category { get; set; }
		public ICollection<Review>? ProductRewiews { get; set; } = new List<Review>();

		//shop owner
		//public int UserId { get; set; }

	}
}
