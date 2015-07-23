using Domain.Entities;
using Domain.Abstract;

namespace WebUI.Controllers.API
{
    public class FamilyRelationsController : BaseApiController<FamilyRelations>
    {
        public FamilyRelationsController()
            : base()
        {
        }

        public FamilyRelationsController(IRepository<FamilyRelations> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}