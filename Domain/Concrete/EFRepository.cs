using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFRepository<T> where T : class
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<House> House
        {
            get { return context.House; }
        }

        public IQueryable<Country> Country
        {
            get { return context.Country; }
        }
    }
}
