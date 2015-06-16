using System.Linq;
using Domain.Entities;


namespace Domain.Abstract
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Country { get; }
        IQueryable<T> House { get; }
    }
}
