using System.Linq;
using System.Linq.Expressions;
using System;
using Domain.Concrete;
using System.Collections.Generic;

namespace Domain.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> All { get; }
        IQueryable<T> GetAll();
        T GetById(int id);
        T GetSingleIncluding(int id, params Expression<Func<T, object>>[] includeProperties);
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

        void ExecProcedure(string name, Dictionary<string, string> parameters = null);
    }
}
