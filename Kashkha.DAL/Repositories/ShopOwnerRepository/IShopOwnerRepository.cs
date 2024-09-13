using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
    public interface IShopOwnerRepository:IGenericRepository<ShopOwner>
    {
        Task<ShopOwner> GetByIdAsync(Guid id);
      //  Task<IEnumerable<ShopOwner>> GetAllAsync();
        Task<ShopOwner> AddAsync(ShopOwner shopOwner);
       Task UpdateAsync(ShopOwner shopOwner);
    Task DeleteAsync(Guid id);

    }
}
