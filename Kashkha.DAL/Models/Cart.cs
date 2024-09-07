
namespace Kashkha.DAL
{
	public class Cart:BaseEntity
	{

        //User ID

        public virtual int ProductId { get; set; }
        public Product? Product { get; set; }


        public int Quantity { get; set; }

    

	}
}
