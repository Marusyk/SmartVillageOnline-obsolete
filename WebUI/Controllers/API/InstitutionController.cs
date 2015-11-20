using Domain.Entities.Dictionaries;
using Domain.Abstract;


namespace WebUI.Controllers.API
{
    public class InstitutionController : BaseApiController<Institution>
    {
        public InstitutionController() { }

        public InstitutionController(IRepository<Institution> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}