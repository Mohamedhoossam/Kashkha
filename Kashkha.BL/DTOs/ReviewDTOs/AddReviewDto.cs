using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.BL
{
	public class AddReviewDto
	{
		public string UserId { get; set; }

		public string UserName { get; set; }

		public string UserComment { get; set; }

		public int ProductId { get; set; }
	}
}
