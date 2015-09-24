using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

namespace Domain.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void ExecProcedure(string name, Dictionary<string, string> parameters = null);
        T GetByIdNoTrack(object id);
        IQueryable<T> Table { get; }
        bool LazyLoadingSwitches { set; }
    }
}
