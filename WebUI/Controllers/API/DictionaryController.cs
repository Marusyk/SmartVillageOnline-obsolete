﻿using Domain.Abstract;
using Domain.Entities.SystemTables;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class DictionaryController : BaseApiController<SYS_Dictionary>
    {

        public DictionaryController() { }

        public DictionaryController(IRepository<SYS_Dictionary> repository)
            : base(repository)
        {
            Repository = repository;
        }

        public override HttpResponseMessage GetById(int id)
        {
            throw new HttpResponseException(HttpStatusCode.BadRequest);
        }

        public override HttpResponseMessage Post([FromBody]SYS_Dictionary entity)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public override HttpResponseMessage Put(int id, [FromBody]SYS_Dictionary entity)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        public override HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }
    }
}
