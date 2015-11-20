using Domain.Abstract;
using Domain.Entities.Dictionaries;

namespace WebUI.Controllers.API
{
    public class StreetController : BaseApiController<Street>
    {
        public StreetController() { }

        public StreetController(IRepository<Street> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}
