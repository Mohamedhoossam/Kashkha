using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
	public class KashkhaContext:DbContext
	{
        public KashkhaContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
