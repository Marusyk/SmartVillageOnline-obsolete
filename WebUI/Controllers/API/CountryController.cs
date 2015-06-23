using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Domain.Entities;
using Domain.Abstract;
using Domain;
using System.Threading.Tasks;

namespace WebUI.Controllers.API
{
    public class CountryController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private IRepository<Country> repository;

        public CountryController()
        {
            repository = unitOfWork.EFRepository<Country>();
        }

        public CountryController(IRepository<Country> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Country> Get()
        {
            IEnumerable<Country> country = repository.Table.ToList();
            return country;           
        }

        public HttpResponseMessage GetById(int id)
        {
            var country = repository.GetById(id);
            if (country == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, country);
        }

        public HttpResponseMessage Post([FromBody]Country country)
        {
            try
            {                         
                repository.Insert(country);
                return Request.CreateResponse(HttpStatusCode.Created, country);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }

        public HttpResponseMessage Delete(int id)
        {
            Country toDelete = repository.GetById(id);
            
            if (toDelete == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                repository.Delete(toDelete);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        public HttpResponseMessage Put([FromBody]Country country)
        {
            Country oldCountry = repository.GetById(country.ID);
            
            if (oldCountry == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                oldCountry.Name = country.Name;
                oldCountry.LastUpdDT = DateTime.Now;
                repository.Update(oldCountry);
                return Request.CreateResponse(HttpStatusCode.OK, oldCountry);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}
