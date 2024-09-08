﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL.Models
{
    public class CartItem
    {
        public int Id { get; set; } 

        public int CartId { get; set; } 

        public int ProductId { get; set; } 

        public string ProductName { get; set; }

        public string PicturUrl { get; set; }

        public decimal Price { get; set; } 

        public int Quantity { get; set; } 

        public decimal TotalPrice => Price * Quantity;
    }
}
