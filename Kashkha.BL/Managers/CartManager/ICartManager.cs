using Kashkha.BL.DTOs.CartDTOs;
using Kashkha.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL.Managers.CartManager
{
    public interface ICartManager
    {
        Task<Cart?> GetCartAsync(string id);

        Task<Cart?> UpdateCart(Cart cart);

        Task<bool> DeleteCart(string cartId);

    }
}
