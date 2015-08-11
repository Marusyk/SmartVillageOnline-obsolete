﻿using Domain.Abstract;
using Domain.Entities;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.OData;

namespace WebUI.Controllers.API
{
    public class PersonController : BaseApiController<Person>
    {
        public PersonController()
            : base()
        {
        }

        public PersonController(IRepository<Person> repository)
            : base(repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<Person> GetByFirstName(string name)
        {
            var persons = repository.Table.Where(f => f.FirstName == name);

            if (persons.Count() == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return persons;
        }
    }
}