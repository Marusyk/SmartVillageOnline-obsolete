using Domain.Abstract;
using Domain.Entities.Dictionaries;
using WebUI.Infrastructure;

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
