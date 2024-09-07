using Kashkha.API;
using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL
{
	public class ProductManager : IProductManager
	{
		private readonly IUnitOfWork _unitOfWork;
		public ProductManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public void Add(AddProductDto productDto)
		{
			//DocumentSettings.UploadFile(productDto.Image)??""
			var imageUrl = "image"; 
			_unitOfWork._ProductRepository.Add(new Product()
			{
				Name = productDto.ProductName,
				Description = productDto.Description,
				Price = productDto.Price,
				Quantity = productDto.Quantity,

			});
			_unitOfWork.Complete();
		}

		public void Delete(Product product)
		{
			throw new NotImplementedException();
		}

		public GetProductDto Get(int id)
		{
			throw new NotImplementedException();
		}

		public List<GetProductDto> GetAll()
		{
			var product = _unitOfWork._ProductRepository.GetAll();
			return product.Select(p => new GetProductDto() {
				ProductName=p.Name ,
				Description=p.Description ,
				Price=p.Price ,
				Quantity=p.Quantity,
				
			}).ToList();
		}

		public void SearchProductByName(string name)
		{
			throw new NotImplementedException();
		}

		public void Update(AddProductDto product)
		{
			throw new NotImplementedException();
		}
	}
}
