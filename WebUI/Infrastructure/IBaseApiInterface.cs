using System.Net.Http;
using System.Web.Http;

namespace WebUI.Infrastructure
{
    public interface IBaseApiInterface<in T>
    {
        // Get all entities
        HttpResponseMessage Get();

        // Get entity with paging
        HttpResponseMessage Get(int pageNo, int pageSize);

        // Get entity by ID
        HttpResponseMessage GetById(int id);

        // Insert new entity
        HttpResponseMessage Post([FromBody]T entity);

        // Remove the entity by ID
        HttpResponseMessage Delete(int id);

        // Update the entity
        HttpResponseMessage Put(int id, [FromBody]T entity);

    }
}
