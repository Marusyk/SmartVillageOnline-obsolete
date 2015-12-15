using Domain.Entities.Dictionaries;
using Domain.Abstract;
using WebUI.Infrastructure;

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