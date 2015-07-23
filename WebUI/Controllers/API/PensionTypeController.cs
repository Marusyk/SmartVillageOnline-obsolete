using Domain.Entities;
using Domain.Abstract;

namespace WebUI.Controllers.API
{
    public class PensionTypeController : BaseApiController<PensionType>
    {
        public PensionTypeController()
            : base()
        {
        }

        public PensionTypeController(IRepository<PensionType> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}