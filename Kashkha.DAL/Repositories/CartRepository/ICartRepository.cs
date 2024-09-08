using Kashkha.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Kashkha.DAL
{
    public interface ICartRepository //مش هنتعامل مع ال DB
    {
       Task<Cart?> GetCartAsync(string id);

        Task<Cart?> UpdateCart(Cart cart);

        Task<bool> DeleteCart(string cartId);
    }
}
