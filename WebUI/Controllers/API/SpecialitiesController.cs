using Domain.Entities.Dictionaries;
using Domain.Abstract;

namespace WebUI.Controllers.API
{
    public class SpecialitiesController : BaseApiController<Specialities>
    {
        public SpecialitiesController()
            : base()
        {
        }

        public SpecialitiesController(IRepository<Specialities> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}