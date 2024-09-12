using Kashkha.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class OrderRepository : GenericRepository<Order>, IOrderRepository
	{
		private readonly KashkhaContext _context;

		public OrderRepository(KashkhaContext context) : base(context)
		{
			_context = context;
		}

		public List<Order> GetAll(int id)
		{

			return _context.Set<Order>().Where(o => o.UserId == id).ToList(); ;

		}

		public Order GetOrderById(int UserId, int OrderId)
		{

			return _context.Set<Order>().FirstOrDefault(o => o.UserId == UserId && o.Id == OrderId);

		}
	}
}
