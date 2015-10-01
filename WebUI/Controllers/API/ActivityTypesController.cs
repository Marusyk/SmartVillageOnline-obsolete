using Domain.Abstract;
using Domain.Entities.Dictionaries;

namespace WebUI.Controllers.API
{
    public class ActivityTypesController : BaseApiController<ActivityTypes>
    {
        public ActivityTypesController()
            : base()
        {
        }

        public ActivityTypesController(IRepository<ActivityTypes> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}