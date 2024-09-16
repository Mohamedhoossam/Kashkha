using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IShopManager
{
    Task<ShopOwnerDTO> GetByIdAsync(Guid id);
	// Task<IEnumerable<ShopOwnerDTO>> GetAllAsync();
	Task<int?> AddAsync(ShopOwnerDTO shopOwnerDto);
    Task UpdateAsync(ShopOwnerDTO shopOwnerDto);
    Task DeleteAsync(Guid id);
}