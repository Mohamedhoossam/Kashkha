using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL.DTOs.CartDTOs
{
    internal class RemoveFromCartDTO
    {
        //Used for removing an item from the cart, typically containing the product ID

        public int ProductId { get; set; }  
    }
}
