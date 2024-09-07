using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kashkha.DAL
{
    public class FavoritRepository : GenericRepository<Favorit>, IFavoritRepository
    {
        public FavoritRepository(KashkhaContext context) : base(context)
        {
        }
    }
}
