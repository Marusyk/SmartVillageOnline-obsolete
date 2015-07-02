using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Infrastructure
{
    interface IBaseApiInterface<T>
    {
        // Get all entities
        IQueryable<T> Get();

        // Get entity by ID
        T GetById(int id);

        // Insert new entity
        HttpResponseMessage Post([FromBody]T entity);

        // Remove the entity by ID
        HttpResponseMessage Delete(int id);

        // Update the entity
        HttpResponseMessage Put([FromBody]T entity);

    }
}
