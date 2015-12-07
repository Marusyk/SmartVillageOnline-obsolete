using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class PeopleController : BaseApiController<People>
    {
        public PeopleController() { }

        public PeopleController(IRepository<People> repository)
            : base(repository)
        {
            Repository = repository;
        }

        [HttpGet]
        [Route("api/People/SetMain/{id}")]
        public HttpResponseMessage SetAsMain(int id)
        {
            var people = Repository.GetSingleIncluding(id, x => x.Persons);

            if (people == null)
            {
                return ErrorMsg(HttpStatusCode.NotFound, $"No people with ID = {id}");
            }

            if (people.IsMain)
            {
                var fullName = people.Persons.FullName;
                return ErrorMsg(HttpStatusCode.OK, $"{fullName} is already set as main");
            }

            try
            {
                var parameters = new Dictionary<string, string>()
                {
                    { "PeopleID", id.ToString() }
                };

                Repository.ExecProcedure("usp_PeopleSetMain", parameters);
                people.IsMain = true;
                return Request.CreateResponse(HttpStatusCode.OK, people);
            }
            catch (Exception ex)
            {
                return ErrorMsg(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
