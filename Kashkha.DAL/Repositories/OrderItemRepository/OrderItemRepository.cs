﻿using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
	{
		
		public OrderItemRepository(KashkhaContext context) : base(context)
		{
		}
	}
}
