using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Domain.Concrete
{
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly EFDbContext context;
        private IDbSet<T> entities;
        private string errorMessage = string.Empty;

        public EFRepository(EFDbContext context)
        {
            this.context = context;
        }

        public T GetById(object id)
        {
            return this.Entities.Find(id);
        }

        public T GetByIdNoTrack(object id)
        {
            return this.Entities.AsNoTracking().FirstOrDefault(p => p.ID == (int)id);
        }

        public void Insert(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("entity");
                }
                this.Entities.Add(entity);
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
                this.Entities.Remove(entity);
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

        public IQueryable<T> Table
        {
            get
            {
                return this.Entities;
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

        public void ExecProcedure(string name, Dictionary<string, string> parameters = null)
        {
            List<object> sqlParameters = new List<object>();
            
            if (parameters != null)
            {
                name = NormalizeProcedureName(name, parameters);
                foreach (var item in parameters)
                {
                    sqlParameters.Add(new SqlParameter(item.Key, item.Value));
                }
             }
               
             context.Database.ExecuteSqlCommand(name, sqlParameters.ToArray());
        }

        private string NormalizeProcedureName(string name, Dictionary<string, string> param)
        {
            if (!name.Contains("@"))
            {
                StringBuilder sb = new StringBuilder();
                string delimiter = "";
                sb.Append(name);

                foreach (var item in param)
                {                    
                    sb.Append(delimiter);
                    sb.Append(" @");
                    sb.Append(item.Key);
                    delimiter = ",";
                }

                name = sb.ToString();
            }
            return name;
        }

        public void SwitchLazyLoading(bool value)
        {
             this.context.Configuration.LazyLoadingEnabled = value;
        }
    }
}
