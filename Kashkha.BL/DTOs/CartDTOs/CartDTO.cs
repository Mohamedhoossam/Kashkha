using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL.DTOs.CartDTOs
{
    internal class CartDTO
    {
        //Represents the overall cart, including a list of items and total price.

        public List<CartItemDTO> Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
