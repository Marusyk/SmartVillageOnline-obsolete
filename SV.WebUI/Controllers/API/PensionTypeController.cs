using Domain.Abstract;
using Domain.Entities.Dictionaries;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class PensionTypeController : BaseApiController<PensionType>
    {
        public PensionTypeController() { }

        public PensionTypeController(IRepository<PensionType> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}