using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebUI.Infrastructure
{
    public interface IBaseApiInterface<T>
    {
        // Get all entities
        Task<HttpResponseMessage> Get();

        // Get entity by ID
        Task<HttpResponseMessage> GetById(int id);

        // Insert new entity
        Task<HttpResponseMessage> Post([FromBody]T entity);

        // Remove the entity by ID
        Task<HttpResponseMessage> Delete(int id);

        // Update the entity
        Task<HttpResponseMessage> Put([FromBody]T entity);

    }
}
