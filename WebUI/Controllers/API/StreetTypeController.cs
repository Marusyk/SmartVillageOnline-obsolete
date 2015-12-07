using Domain.Abstract;
using Domain.Entities.Dictionaries;
using WebUI.Infrastructure;


namespace WebUI.Controllers.API
{
    public class StreetTypeController : BaseApiController<StreetType>
    {
        public StreetTypeController() { }

        public StreetTypeController(IRepository<StreetType> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}
