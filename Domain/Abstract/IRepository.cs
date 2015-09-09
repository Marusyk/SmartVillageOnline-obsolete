using System.Linq;
using System.Data.Entity;

namespace Domain.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void ExecProcedure(string name, string[] param);
        IQueryable<T> Table { get; }
    }
}
