using Domain.Abstract;
using Domain.Entities;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Controllers.API
{
    public class HouseController : BaseApiController<House>
    {        

        public HouseController()
            : base()
        {            
        }

        public HouseController(IRepository<House> repository)
            : base(repository)
        {
            this.repository = repository;
        }
        
        public HttpResponseMessage GetByYear(int year)
        {
            var houses = repository.FindBy(x => x.Year == year);

            if (houses == null || !houses.Any())
            {
                var message = string.Format("No house where Year = {0}", year);
                return ErrorMsg(HttpStatusCode.NotFound, message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, houses);
        }

        public override HttpResponseMessage Get()
        {
            var houses = repository.FindBy(y => y.Year == DateTime.Now.Year);

            if (houses == null || !houses.Any())
            {
                var message = "House: No content";
                return ErrorMsg(HttpStatusCode.NotFound, message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, houses);
        }
    }
}
