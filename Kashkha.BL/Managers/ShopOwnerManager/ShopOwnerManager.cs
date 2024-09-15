using AutoMapper;
using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ShopOwnerManager : IShopOwnerManager
{
    private readonly IShopRepository _shopOwnerRepo;
    private readonly IMapper _mapper;

    public ShopOwnerManager(IShopRepository shopOwnerRepo, IMapper mapper)
    {
        _shopOwnerRepo = shopOwnerRepo;
        _mapper = mapper;
    }

    public async Task<ShopOwnerDTO> GetByIdAsync(Guid id)
    {
        var shopOwner = await _shopOwnerRepo.GetByIdAsync(id);
        return _mapper.Map<ShopOwnerDTO>(shopOwner);
    }

    // public async Task<IEnumerable<ShopOwnerDTO>> GetAllAsync()
    // {
    //     var shopOwners = await _shopOwnerRepo.GetAllAsync();
    //     return _mapper.Map<IEnumerable<ShopOwnerDTO>>(shopOwners);
    // }

    public async Task<ShopOwnerDTO> AddAsync(ShopOwnerDTO shopOwnerDto)
    {
        var shopOwner = _mapper.Map<Shop>(shopOwnerDto);
        await _shopOwnerRepo.AddAsync(shopOwner);
        return _mapper.Map<ShopOwnerDTO>(shopOwner);
    }

    public async Task UpdateAsync(ShopOwnerDTO shopOwnerDto)
    {
        var shopOwner = _mapper.Map<Shop>(shopOwnerDto);
        await _shopOwnerRepo.UpdateAsync(shopOwner);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _shopOwnerRepo.DeleteAsync(id);
    }
}