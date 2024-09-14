using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;


namespace Kashkha.DAL
{
	public class Shop : BaseEntity
    {

        public string Name { get; set; }
        [NotMapped]

        public virtual Address Address { get; set; }
    }

}
