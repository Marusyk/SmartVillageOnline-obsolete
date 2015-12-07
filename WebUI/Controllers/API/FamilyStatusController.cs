using Domain.Abstract;
using Domain.Entities.Dictionaries;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class FamilyStatusController : BaseApiController<FamilyStatus>
    {
        public FamilyStatusController() { }

        public FamilyStatusController(IRepository<FamilyStatus> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}