
namespace Kashkha.DAL
{
	public class ProductRepository:GenericRepository<Product>,IProductRepository
	{
		private readonly KashkhaContext _context;
		public ProductRepository(KashkhaContext context):base(context)
		{
			_context = context;
		}

		public IQueryable<Product> SearchProductByName(string name)
		{
			return _context.Set<Product>().Where(p=>p.Name.Contains(name, StringComparison.CurrentCultureIgnoreCase));
		}
	}
}
