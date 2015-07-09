using Domain.Entities;
using Domain.Abstract;


namespace WebUI.Controllers.API
{
    public class CityTypeController : BaseApiController<CityType>
    {
        public CityTypeController()
            : base()
        {
        }

        public CityTypeController(IRepository<CityType> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}

