using System.Linq;
using System.Web.Http;
using Domain.Entities;
using Domain.Abstract;
using Domain.Concrete;

namespace WebUI.Controllers.API
{
    public class HouseController : ApiController
    {
        private IHouseRepository repository;

        public HouseController()
        {
            this.repository = new EFHouseRepository();
        }

        public HouseController(IHouseRepository repo)
        {
            this.repository = repo;
        }

        public IQueryable<House> Get()
        {
            return repository.House;
        }
    }
}
