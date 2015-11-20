using Domain.Entities.Dictionaries;
using Domain.Abstract;

namespace WebUI.Controllers.API
{
    public class SpecialitiesController : BaseApiController<Specialities>
    {
        public SpecialitiesController() { }

        public SpecialitiesController(IRepository<Specialities> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}