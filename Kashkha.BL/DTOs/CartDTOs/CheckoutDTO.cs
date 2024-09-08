using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL.DTOs.CartDTOs
{
    internal class CheckoutDTO
    {
        //Represents the data needed for the checkout process, such as payment information and shipping address.

        public string PaymentMethod { get; set; }
        public string ShippingAddress { get; set; }
        public List<CartItemDTO> Items { get; set; }
    }
}
