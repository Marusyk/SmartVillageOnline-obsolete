using System.Linq;
using Domain.Entities;


namespace Domain.Abstract
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> SelectAll();

        T SelectByID(object id);

        void Insert(T obj);

        void Update(T obj);

        void Delete(object id);

        void Save();
        
        //IQueryable<T> House { get; }

        ///IQueryable<T> Country { get; }

        //void InsertCountry(Country obj);
    }
}
