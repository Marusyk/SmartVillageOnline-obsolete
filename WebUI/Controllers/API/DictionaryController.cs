using Domain.Abstract;
using Domain.Entities.SystemTables;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Controllers.API
{
    public class DictionaryController : ApiBaseController<SYS_Dictionary>
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

        public override SYS_Dictionary GetById(int id)
        {
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        public override HttpResponseMessage Post([FromBody]SYS_Dictionary entity)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public override HttpResponseMessage Put([FromBody]SYS_Dictionary entity)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public override HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
