using Domain.Abstract;
using Domain.Entities;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace WebUI.Controllers.API
{
    public class HouseController : BaseApiController<House>
    {

        public HouseController() { }

        public HouseController(IRepository<House> repository)
            : base(repository)
        {
            Repository = repository;
        }
        
        public HttpResponseMessage GetByYear(int year)
        {
            var houses = Repository.FindBy(x => x.Year == year);

            if (houses == null || !houses.Any())
            {
                var message = string.Format("No house where Year = {0}", year);
                return ErrorMsg(HttpStatusCode.NotFound, message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, houses);
        }

        public override HttpResponseMessage Get()
        {
            var houses = Repository.FindBy(y => y.Year == DateTime.Now.Year);

            if (houses == null || !houses.Any())
            {
                const string message = "House: No content";
                return ErrorMsg(HttpStatusCode.NotFound, message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, houses);
        }
    }
}
