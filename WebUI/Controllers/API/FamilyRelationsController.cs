using Domain.Abstract;
using Domain.Entities.Dictionaries;

namespace WebUI.Controllers.API
{
    public class FamilyRelationsController : BaseApiController<FamilyRelations>
    {
        public FamilyRelationsController() { }

        public FamilyRelationsController(IRepository<FamilyRelations> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}