using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kashkha.DAL
{
    public class ShopOwnerRepository : GenericRepository<ShopOwner>, IShopOwnerRepository
    {private readonly KashkhaContext _context;
        public ShopOwnerRepository(KashkhaContext context) : base(context)
        {
            _context = context;
        }

         public async Task<ShopOwner> GetByIdAsync(Guid id)
    {
        return await _context.ShopOwners.FindAsync(id);
    }

    // public async Task<IEnumerable<ShopOwner>> GetAllAsync()
    // {
    //     return await _context.ShopOwners.ToListAsync();
    // }

    public async Task<ShopOwner> AddAsync(ShopOwner shopOwner)
    {
        await _context.ShopOwners.AddAsync(shopOwner);
        await _context.SaveChangesAsync();
        return shopOwner;
    }

    public async Task UpdateAsync(ShopOwner shopOwner)
    {
        _context.Entry(shopOwner).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var shopOwner = await _context.ShopOwners.FindAsync(id);
        if (shopOwner != null)
        {
            _context.ShopOwners.Remove(shopOwner);
            await _context.SaveChangesAsync();
        }
    }
    }
}
