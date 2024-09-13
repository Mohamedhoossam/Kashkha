using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Kashkha.DAL
{
	public class Order : BaseEntity
	{
		public int UserId { get; set; }
		//public User? user { get; set; }

		public DateTime OrderDate { get; set; }
		public DateTime ShippingDate { get; set; }
		public decimal TotalPrice { get; set; }
		public OrderStatus OrderStatus { get; set; }
		public PaymentStatus PaymentStatus { get; set; }

		public string? Carrier { get; set; }
		public string? TrackingNumber { get; set; }
		public DateTime PaymentDate { get; set; }

		//Stripe Properties
		public string? SessionId { get; set; }
		public string? PaymentIntentId { get; set; }

		//Data of Customer
		public Address OrderAddress { get; set; }


		public ICollection<OrderItem> orderItems { get; set; } = new List<OrderItem>();

		//shop owner
		[ForeignKey("ShopOwner")]
		public Guid ShopOwnerId { get; set; }
		public ShopOwner ShopOwner { get; set; }




	}
}
