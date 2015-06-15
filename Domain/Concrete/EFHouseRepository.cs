using System.Linq;
using Domain.Abstract;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFHouseRepository : IHouseRepository
    {
        private EFDbContext context = new EFDbContext();
        
        public IQueryable<House> House
        {
            get { return context.House; }
        }
    }
}
