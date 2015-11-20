using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Controllers.API
{
    public class PeopleController : BaseApiController<People>
    {
        public PeopleController()
            : base()
        {
        }

        public PeopleController(IRepository<People> repository)
            : base(repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [Route("api/People/SetMain/{id}")]
        public HttpResponseMessage SetAsMain(int id)
        {
            People people = repository.GetSingleIncluding(id, x => x.Persons);

            if (people == null)
            {
                return ErrorMsg(HttpStatusCode.NotFound, string.Format("No people with ID = {1}", id));
            }

            if (people.IsMain)
            {
                string fullName = people.Persons.FullName;
                return ErrorMsg(HttpStatusCode.OK, string.Format("{0} is already set as main", fullName));
            }

            try
            {
                var parameters = new Dictionary<string, string>();
                parameters.Add("PeopleID", id.ToString());

                repository.ExecProcedure("usp_PeopleSetMain", parameters);
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
