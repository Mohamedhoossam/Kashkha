using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL
{
	public class AddReviewDto
	{
		public int CustomerId { get; set; }

		public string CustomerName { get; set; }

		public string CustomerComment { get; set; }

		public int ProductId { get; set; }
	}
}
