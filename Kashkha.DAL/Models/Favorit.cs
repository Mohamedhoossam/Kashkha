using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class Favorit
	{
		public ICollection<Product>? Products { get; set; } = new List<Product>();
	}
}
