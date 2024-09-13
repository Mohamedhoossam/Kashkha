using System;
using System.Linq;
using System.Text;


namespace Kashkha.DAL
{
    public class ShopOwner : BaseEntity
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ShopName { get; set; }
        public string Address { get; set; }
        public string ProfilePicture { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }
    }

}
