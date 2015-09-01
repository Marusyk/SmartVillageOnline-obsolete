using Domain.Abstract;
using Domain.Entities.SystemTables;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebUI.Controllers.API
{
    public class DictionaryController : BaseApiController<SYS_Dictionary>
    {

        public DictionaryController()
            : base()
        {            
        }

        public DictionaryController(IRepository<SYS_Dictionary> repository)
            : base(repository)
        {
            this.repository = repository;
        }

        public override Task<HttpResponseMessage> GetById(int id)
        {
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        public override Task<HttpResponseMessage> Post([FromBody]SYS_Dictionary entity)
        {
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        public override Task<HttpResponseMessage> Put([FromBody]SYS_Dictionary entity)
        {
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        public override Task<HttpResponseMessage> Delete(int id)
        {
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }
    }
}
