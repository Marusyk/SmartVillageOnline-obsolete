using Domain.Abstract;
using Domain.Entities;
using System.Data;
using System.Linq;

namespace Domain.Concrete
{
    public class EFRepository<T> : IRepository<T> where T : class
    {
        private EFDbContext<T> context = new EFDbContext<T>();

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
