using Domain.Entities;
using Domain.Abstract;

namespace WebUI.Controllers.API
{
    public class MaterialsController : BaseApiController<Materials>
    {
        public MaterialsController()
            : base()
        {
        }

        public MaterialsController(IRepository<Materials> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}