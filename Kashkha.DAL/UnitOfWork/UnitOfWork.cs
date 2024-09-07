using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class UnitOfWork : IDisposable, IUnitOfWork
	{
		private readonly KashkhaContext _context;
		public IProductRepository _ProductRepository { get; private set; }
		public IReviewRepository _reviewRepository { get; private set; }
		public IOrderRepository _orderRepository { get; private set; }
		public IOrderItemRepository _orderItemRepository { get; private set; }


		public UnitOfWork(KashkhaContext context)
		{
			_ProductRepository = new ProductRepository(context);
			_reviewRepository = new ReviewRepository(context);
			_orderRepository = new OrderRepository(context);
			_orderItemRepository= new OrderItemRepository(context);
			_context = context;
		}



		public void Dispose()
		{
			_context.Dispose();
		}

		public int Complete()
		{
			return _context.SaveChanges();
		}
	}
}
