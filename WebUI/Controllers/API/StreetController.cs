using Domain.Entities;
using Domain.Abstract;

namespace WebUI.Controllers.API
{
    public class StreetController : BaseApiController<Street>
    {
        public StreetController()
            : base()
        {
        }

        public StreetController(IRepository<Street> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}
