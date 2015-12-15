using Domain.Abstract;
using Domain.Entities.Dictionaries;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class CityController : BaseApiController<City>
    {
        public CityController() { }

        public CityController(IRepository<City> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}