using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL.DTOs.CartDTOs
{
    internal class UpdateCartItemDTO
    {
        //Used for updating the quantity of an item in the cart

        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
