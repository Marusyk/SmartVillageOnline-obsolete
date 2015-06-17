using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private EFDbContext context = new EFDbContext();
      
        IQueryable<T> IRepository<T>.House
        {
            get { return context.House as IQueryable<T>; }
        }

        IQueryable<T> IRepository<T>.Country
        {
            get { return context.Country as IQueryable<T>; }
        }
    }
}
