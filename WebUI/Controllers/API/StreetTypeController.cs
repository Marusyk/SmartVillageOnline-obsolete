using Domain.Entities;
using Domain.Abstract;


namespace WebUI.Controllers.API
{
    public class StreetTypeController : BaseApiController<StreetType>
    {
        public StreetTypeController()
            : base()
        {
        }

        public StreetTypeController(IRepository<StreetType> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}
