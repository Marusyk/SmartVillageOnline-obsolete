using System.Linq;
using Domain.Entities;
using System.Data.Entity;
using Domain.Concrete;

namespace Domain.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }
        IDbSet<T> Entities { get; }
    }
}
