using Domain.Entities;
using Domain.Abstract;

namespace WebUI.Controllers.API
{
    public class FamilyStatusController : BaseApiController<FamilyStatus>
    {
        public FamilyStatusController()
            : base()
        {
        }

        public FamilyStatusController(IRepository<FamilyStatus> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}