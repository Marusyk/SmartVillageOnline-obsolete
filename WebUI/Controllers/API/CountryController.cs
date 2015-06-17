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
        private IRepository<Country> rep;

        public CountryController()
        {
            this.rep = new EFRepository<Country>();
        }

        public CountryController(IRepository<Country> repo)
        {
            this.rep = repo;
        }

        [HttpGet]
        public IQueryable<Country> Get()
        {
            return rep.Country;
        }
    }
}
