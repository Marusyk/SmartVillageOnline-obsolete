using System.Linq;
using System.Web.Http;
using Domain.Entities;
using Domain.Abstract;
using Domain.Concrete;

namespace WebUI.Controllers.API
{
    public class HouseController : ApiController
    {
        private IRepository<House> rep;

        public HouseController()
        {
            this.rep = new EFRepository<House>();
        }

        public HouseController(IRepository<House> repo)
        {
            this.rep = repo;
        }

        [HttpGet]
        public IQueryable<House> Get()
        {
            return rep.House;
        }
    }
}
