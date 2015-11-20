using Domain.Abstract;
using Domain.Entities.Dictionaries;

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