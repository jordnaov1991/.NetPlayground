using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.DataAccess
{
    //Base refactoring.
    public class BaseRepository
    {
        protected MoviesDBEntities dbContext = new MoviesDBEntities();
    }
}
