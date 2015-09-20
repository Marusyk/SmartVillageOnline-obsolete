using Domain.Abstract;
using Domain.Entities;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

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


        /// <summary>
        /// Gets all houses by year.
        /// </summary>
        /// <param name="year">The Year of houses</param>
        /// <returns></returns>
        [EnableQuery]
        public HttpResponseMessage GetByYear(int year)
        {                        
            var houses = repository.Table.Where(f => f.Year == year);

            if (houses == null || !houses.Any())
            {
                var message = string.Format("No house where Year = {0}", year);
                return ErrorMsg(HttpStatusCode.NotFound, message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, houses); ;
        }

        /// <summary>
        /// Gets all houses by current year
        /// </summary>
        /// <returns></returns>
        [EnableQuery]
        public override HttpResponseMessage Get()
        {
            var houses = repository.Table.Where(y => y.Year == DateTime.Now.Year);

            if (houses == null || !houses.Any())
            {
                var message = "House: No content";
                return ErrorMsg(HttpStatusCode.NotFound, message);
            }
            return Request.CreateResponse(HttpStatusCode.OK, houses);
        }
    }
}
