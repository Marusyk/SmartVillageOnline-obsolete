using Domain;
using Domain.Concrete;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Controllers.API
{
    public class HouseController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private EFRepository<House> repository;

        public HouseController()
        {
            repository = unitOfWork.EFRepository<House>();
        }

        public IEnumerable<House> Get()
        {
            IEnumerable<House> country = repository.Table.ToList();
            return country;
        }

        public HttpResponseMessage Post([FromBody]House house)
        {
            try
            {
                repository.Insert(house);
                return Request.CreateResponse(HttpStatusCode.Created, house);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }

        }

        public HttpResponseMessage Delete(int id)
        {
            House toDelete = repository.GetById(id);

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

        public HttpResponseMessage Put([FromBody]House house)
        {
            House oldHouse = repository.GetById(house.ID);

            if (oldHouse == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                oldHouse.HouseNr = house.HouseNr;
                oldHouse.KadastrNr = house.KadastrNr;
                oldHouse.PhoneCode = house.PhoneCode;
                oldHouse.PhoneNr = house.PhoneNr;
                oldHouse.Year = house.Year;
                oldHouse.AddressID = house.AddressID;
                oldHouse.BuildNr = house.BuildNr;
                oldHouse.Code = house.Code;
                oldHouse.FaxNr = house.FaxNr;                
                repository.Update(oldHouse);
                return Request.CreateResponse(HttpStatusCode.OK, oldHouse);
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
