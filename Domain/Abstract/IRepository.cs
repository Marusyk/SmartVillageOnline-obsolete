using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace Domain.Abstract
{
    public interface IRepository<T> where T : IEntity
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> All { get; }
        IQueryable GetAll();
        T GetById(int id);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        PaginatedList<T> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector);
        PaginatedList<T> Paginate<TKey>(int pageIndex, int pageSize, 
            Expression<Func<T, TKey>> keySelector,
            Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties);

        void Add(T entity);
        void Edit(T entity);
        void Delete(T entity);
        void Save();

      /*  void ExecProcedure(string name, Dictionary<string, string> parameters = null);
        T GetByIdNoTrack(object id);
        IQueryable<T> Table { get; }
        void SwitchLazyLoading(bool value);*/
    }
}
