
using Kashkha.DAL.Models;

namespace Kashkha.DAL
{
	public class Cart
	{

        //User ID

        public string Id { get; set; }  

        //public int UserId { get; set; }

        
        public virtual ICollection<CartItem> Items { get; set; } = new List<CartItem>();

        public decimal TotalPrice { get; set; }

        public Cart(string id)
        {
            Id= id;
        }

    }
}
