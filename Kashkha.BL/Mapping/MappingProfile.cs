using AutoMapper;
using Kashkha.DAL.Models;
using Kashkha.BL.DTOs;
using Kashkha.DAL;

namespace Kashkha.BL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Favorite, FavoriteDTO>();
            CreateMap<CreateFavoriteDTO, Favorite>();
            CreateMap<Product, UpdateProductDto>();
        }

      
    }

   
}