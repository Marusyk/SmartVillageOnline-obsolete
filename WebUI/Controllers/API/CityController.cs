using Domain.Abstract;
using Domain.Entities.Dictionaries;

namespace WebUI.Controllers.API
{
    public class CityController : BaseApiController<City>
    {
        public CityController()
            : base()
        {
        }

        public CityController(IRepository<City> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}