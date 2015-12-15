using Domain.Entities.Dictionaries;
using Domain.Abstract;
using WebUI.Infrastructure;


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