﻿using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

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
            People people = repository.GetById(id);            

            if (people == null)
            {
                return ErrorMsg(HttpStatusCode.NotFound, string.Format("No people with ID = {1}", id));
            }

            if (people.IsMain == true)
            {
                return ErrorMsg(HttpStatusCode.OK, string.Format("{0} is already set as main", people.FullName)); // no name
            }

            try
            {
                var parameters = new Dictionary<string, string>();
                parameters.Add("PeopleID", id.ToString());

                repository.ExecProcedure("usp_PeopleSetMain", parameters);
                return Request.CreateResponse(HttpStatusCode.OK, repository.GetById(id)); // some problem here
            }
            catch (Exception ex)
            {
                return ErrorMsg(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
