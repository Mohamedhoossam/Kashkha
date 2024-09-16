using Kashkha.API;
using Kashkha.DAL;
using Microsoft.Extensions.Configuration;
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
		private readonly IConfiguration _configuration;

		public ProductManager(IUnitOfWork unitOfWork,IConfiguration configuration)
		{
			_unitOfWork = unitOfWork;
			_configuration = configuration;
		}
		public void Add(AddProductDto productDto,string userId)
		{
			var imageUrl = DocumentSettings.UploadFile(productDto.Image);
			var user=_unitOfWork._usersRepository.GetFirstOrDefault(userId);
			_unitOfWork._ProductRepository.Add(new Product()
			{
				Name = productDto.ProductName,
				Description = productDto.Description,
				Price = productDto.Price,
				Quantity = productDto.Quantity,
				PictureUrl= imageUrl ?? string.Empty,
				CategoryId=productDto.CategoryId,
				ShopId= (Guid)user.ShopId,
				
			});
			_unitOfWork.Complete();
		}

		public int? Delete(Product product,string userId)
		{
		   
			if(product.Shop.UserId != userId)
			{
				return null;
			}

			_unitOfWork._ProductRepository.Delete(product);
			var result = _unitOfWork.Complete();
			if (result > 0)
			{
				if (!string.IsNullOrEmpty(product.PictureUrl))
					DocumentSettings.DeleteFile(product.PictureUrl);
			}
			return result;
		}
		public Product Get(int id)
		{
			var product = _unitOfWork._ProductRepository.GetFirstOrDefault(id);
			product.PictureUrl = _configuration["ApiBaseUrl"] + product.PictureUrl;
			return product;
		}

		public Product GetWithOutUrl(int id)
		{
			var product = _unitOfWork._ProductRepository.GetByIdWithCategory(id);
			product.PictureUrl =product.PictureUrl;
			return product;
		}
	

		public List<GetProductDto> GetAll(string? category)
		{
			List<Product> product;
			if (string.IsNullOrEmpty(category))
				 product = _unitOfWork._ProductRepository.GetAllWithCategory();
			else
			 product = _unitOfWork._ProductRepository.SearchProductByCategoryName(category).ToList();

			return product.Select(p => new GetProductDto() {
				Id= p.Id,
				ProductName=p.Name ,
				Description=p.Description ,
				Price=p.Price,
				Quantity=p.Quantity,
				CategoryId=p.CategoryId,
				Image= _configuration["ApiBaseUrl"] + p.PictureUrl,
				CategoryName=p.Category!.Name,
				ShopId=p.Shop.Id,
				ShopImage= _configuration["ApiBaseUrl"] + p.Shop.ProfilePicture,
				ShopName=p.Shop.ShopName,
				ProductRewiews= p.Rewiews
			}).ToList();
		}

	
		public void Update(UpdateProductDto product)
		{
			var newProduct = _unitOfWork._ProductRepository.GetFirstOrDefault(product.Id);
			string oldImage="";
			newProduct!.Name = product.ProductName?? newProduct!.Name;
			newProduct!.Description = product.Description?? newProduct!.Description;
			newProduct!.Price = product.Price ?? newProduct!.Price;
			newProduct!.Quantity = product.Quantity ?? newProduct!.Quantity;
			newProduct!.CategoryId = product.CategoryId ?? newProduct!.CategoryId;
			if(product.Image !=null)
			{
				oldImage = newProduct.PictureUrl;
				newProduct.PictureUrl = DocumentSettings.UploadFile(product.Image);
			}

			var result = _unitOfWork.Complete();

			if (result > 0)
				DocumentSettings.DeleteFile(oldImage);


		}

		public bool isFound(int id)
		{
			return _unitOfWork._ProductRepository.isFound(id);
		}

	
	}
}
