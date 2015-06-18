using Domain.Abstract;
using Domain.Entities;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;

namespace Domain.Concrete
{
    public class EFRepository<T> where T : BaseEntity
    {
        private readonly EFDbContext context;
        private IDbSet<T> entities;
        string errorMessage = string.Empty;

        public EFRepository(EFDbContext context)
        {
            this.context = context;
        }

        public T GetById(object id)
        {
            return this.entities.Find(id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.entities.Add(entity);
                this.context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }
        }

        public void Update(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }                
                this.context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }
        }

        public void Delete(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.entities.Remove(entity);
                this.context.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        errorMessage += string.Format("Property: {0} Error: {1}",
                        validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                    }
                }
                throw new Exception(errorMessage, dbEx);
            }
        }

        public virtual IQueryable<T> Table
        {
            get
            {
                return this.entities;
            }
        }

        private IDbSet<T> Entities
        {
            get
            {
                if (entities == null)
                {
                    entities = context.Set<T>();
                }
                return entities;
            }
        }
        //public void Delete(object id)
        //{
        //    T existing = context.TableName.Find(id);
        //    context.TableName.Remove(existing);
        //}

        public void Insert(T obj)
        {
            context.Country.Add(obj);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IQueryable<T> SelectAll()
        {
            return context.Country as IQueryable<T>;
        }

        //public T SelectByID(object id)
        //{
        //    return context.TableName.Find(id);
        //}

        //public void Update(T obj)
        //{
        //    context.TableName.Attach(obj);
        //    context.Entry(obj).State = EntityState.Modified;
        //}

        //IQueryable<T> IRepository<T>.House
        //{
        //    get { return context.House as IQueryable<T>; }
        //}

        //IQueryable<T> IRepository<T>.Country
        //{
        //    get { return context.Country as IQueryable<T>; }
        //}

    }
}
