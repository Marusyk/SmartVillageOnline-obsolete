using Domain.Abstract;
using Domain.Entities;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebApi.Controllers.API
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

        [HttpGet]
        [Queryable]
        public IQueryable<House> GetByYear(int year)
        {                        
            var houses = repository.Table.Where(f => f.Year == year);

            if (houses.Count() == 0)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return houses;
        }
    }
}
