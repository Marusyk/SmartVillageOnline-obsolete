using Domain.Abstract;
using Domain.Entities;
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
        /// TEST
        /// </summary>
        /// <param name="year">ParamBy</param>
        /// <returns></returns>
        [HttpGet]
        [EnableQuery]
        public IQueryable<House> GetByYear(int year)
        {                        
            var houses = repository.Table.Where(f => f.Year == year);

            if (houses.Count() == 0)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound)
                {
                    Content = new StringContent(string.Format("No house where Year = {0}", year)),
                    ReasonPhrase = "House Not Found"
                };
                throw new HttpResponseException(resp);
            }

            return houses;
        }
    }
}
