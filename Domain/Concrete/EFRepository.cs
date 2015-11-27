using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Domain.Concrete
{
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly EFDbContext _context;
        private IDbSet<T> _entities;
        private string _errorMessage = string.Empty;

        public EFRepository(EFDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _context = context;
        }

        private IDbSet<T> Entities
        {
            get
            {
                _entities = _entities ?? _context.Set<T>();
                return _entities;
            }
        }

        public virtual IQueryable<T> GetAll()
        {
            return Entities;
        }

        public virtual IQueryable<T> All
        {
            get
            {
                return GetAll();
            }
        }

        public virtual IQueryable<T> AllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Entities;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query;
        }

        public virtual T GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.ID == id);
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public virtual PaginatedList<T> Paginate<TKey>(int pageIndex, int pageSize, Expression<Func<T, TKey>> keySelector)
        {
            return Paginate(pageIndex, pageSize, keySelector, null);
        }

        public virtual PaginatedList<T> Paginate<TKey>(int pageIndex, int pageSize,
            Expression<Func<T, TKey>> keySelector,
            Expression<Func<T, bool>> predicate,
            params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = AllIncluding(includeProperties).OrderBy(keySelector);

            query = (predicate == null)
                ? query
                : query.Where(predicate);

            return query.ToPaginatedList(pageIndex, pageSize);
        }

        public virtual void Add(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                DbEntityEntry dbEntityEntry = _context.Entry<T>(entity);
                Entities.Add(entity);
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public virtual void Edit(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                DbEntityEntry dbEntityEntry = _context.Entry<T>(entity);
                dbEntityEntry.State = EntityState.Modified;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public virtual void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }

                DbEntityEntry dbEntityEntry = _context.Entry<T>(entity);
                dbEntityEntry.State = EntityState.Deleted;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        _errorMessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public void ExecProcedure(string name, Dictionary<string, string> parameters = null)
        {
            var sqlParameters = new List<object>();

            if (parameters != null)
            {
                name = NormalizeProcedureName(name, parameters);
                foreach (var item in parameters)
                {
                    sqlParameters.Add(new SqlParameter(item.Key, item.Value));
                }
            }

            _context.Database.ExecuteSqlCommand(name, sqlParameters.ToArray());
        }

        private static string NormalizeProcedureName(string name, Dictionary<string, string> param)
        {
            if (name.Contains("@"))
            {
                return name;
            }

            var sb = new StringBuilder();
            var delimiter = string.Empty;
            sb.Append(name);

            foreach (var item in param)
            {
                sb.Append(delimiter);
                sb.Append(" @");
                sb.Append(item.Key);
                delimiter = ",";
            }

            name = sb.ToString();

            return name;
        }

        public T GetSingleIncluding(int id, params Expression<Func<T, object>>[] includeProperties)
        {
            var query = Entities.Where(x => x.ID == id);

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return query.First();
        }

        public T GetSingleIncluding(int id, string[] includeProperties)
        {
            var query = Entities.Where(x => x.ID == id);

            if (includeProperties == null || !includeProperties.Any()) return query.First();
            query = query.Include(includeProperties.First());
            query = includeProperties
                .Skip(1)
                .Aggregate(query, (current, include) => current.Include(include));

            return query.First();
        }

    }
}
