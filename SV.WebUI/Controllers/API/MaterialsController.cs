using Domain.Abstract;
using Domain.Entities.Dictionaries;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class MaterialsController : BaseApiController<Materials>
    {
        public MaterialsController() { }

        public MaterialsController(IRepository<Materials> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}