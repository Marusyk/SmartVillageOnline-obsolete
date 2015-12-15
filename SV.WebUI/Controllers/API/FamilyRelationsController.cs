using Domain.Abstract;
using Domain.Entities.Dictionaries;
using WebUI.Infrastructure;

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