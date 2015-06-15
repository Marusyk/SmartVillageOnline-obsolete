using System.Linq;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IHouseRepository
    {
        IQueryable<House> House { get; }        
    }
}
