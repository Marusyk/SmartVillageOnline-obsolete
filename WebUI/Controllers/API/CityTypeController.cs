using Domain.Abstract;
using Domain.Entities.Dictionaries;


namespace WebUI.Controllers.API
{
    public class CityTypeController : BaseApiController<CityType>
    {
        public CityTypeController() { }

        public CityTypeController(IRepository<CityType> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}

