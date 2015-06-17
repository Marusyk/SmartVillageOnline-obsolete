using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Entities;
using Domain.Abstract;
using Domain.Concrete;

namespace WebUI.Controllers.API
{
    public class CountryController : ApiController
    {
        private IRepository<Country> repository = null;

        public CountryController()
        {
            this.repository = new EFRepository<Country>();
        }

        public CountryController(IRepository<Country> repository)
        {
            this.repository = repository;
        }

        public IQueryable<Country> Get()
        {
            return repository.SelectAll();
        }


        public HttpResponseMessage Post([FromBody]Country country)
        {
            try
            {
                int id = 6; // repository.SelectAll().Max(x => x.CountryID);
                country.CountryID = id + 1;
                country.Name = "TEST";
                repository.Insert(country);
                return Request.CreateResponse(HttpStatusCode.Created, country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
