using DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Base
{
    public class AbstractRepository
    {
        protected EfDbContext context = null;

        protected AbstractRepository()
        {
            context = new EfDbContext();
        }

        protected AbstractRepository(EfDbContext context)
        {
            this.context = context;
        }
    }
}
