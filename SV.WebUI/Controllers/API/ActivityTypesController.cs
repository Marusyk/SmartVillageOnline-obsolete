using Domain.Abstract;
using Domain.Entities.Dictionaries;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class ActivityTypesController : BaseApiController<ActivityTypes>
    {
        public ActivityTypesController() { }

        public ActivityTypesController(IRepository<ActivityTypes> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}