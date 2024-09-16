using AutoMapper;
using Kashkha.BL;
using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ShopManager : IShopManager
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

    public ShopManager(IUnitOfWork unitOfWork, IMapper mapper)
    {
      
		_unitOfWork = unitOfWork;
		_mapper = mapper;
    }

    public async Task<ShopOwnerDTO> GetByIdAsync(Guid id)
    {
        var shopOwner = await _unitOfWork._shopRepository.GetByIdAsync(id);
        return _mapper.Map<ShopOwnerDTO>(shopOwner);
    }

    // public async Task<IEnumerable<ShopOwnerDTO>> GetAllAsync()
    // {
    //     var shopOwners = await _shopOwnerRepo.GetAllAsync();
    //     return _mapper.Map<IEnumerable<ShopOwnerDTO>>(shopOwners);
    // }

    public async Task<ShopOwnerDTO> AddAsync(ShopOwnerDTO shopOwnerDto)
    {
        var img = DocumentSettings.UploadFile(shopOwnerDto.ProfilePicture);

        var shopOwner = _mapper.Map<Shop>(shopOwnerDto);
        await _unitOfWork._shopRepository.AddAsync(shopOwner);
        shopOwner.ProfilePicture = img;
        
        return _mapper.Map<ShopOwnerDTO>(shopOwner);
    }

    public async Task UpdateAsync(ShopOwnerDTO shopOwnerDto)
    {
        var shopOwner = _mapper.Map<Shop>(shopOwnerDto);
        await _unitOfWork._shopRepository.UpdateAsync(shopOwner);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _unitOfWork._shopRepository.DeleteAsync(id);
    }
}