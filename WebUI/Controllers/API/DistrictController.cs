using Domain.Entities.Dictionaries;
using Domain.Abstract;

namespace WebUI.Controllers.API
{
    public class DistrictController : BaseApiController<District>
    {
        public DistrictController()
            : base()
        {
        }

        public DistrictController(IRepository<District> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}