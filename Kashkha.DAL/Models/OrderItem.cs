﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class OrderItem : BaseEntity
	{
		public int OrderId { get; set; }

		[JsonIgnore]
		public Order? Order { get; set; }

		public int ProductId { get; set; }

		public string ProductName { get; set; }

		public string PicturUrl { get; set; }

		public decimal Price { get; set; }

		public int Quantity { get; set; }

		public decimal TotalPrice => Price * Quantity;

	
	}
}
