using Domain.Entities;
using Domain.Abstract;

namespace WebUI.Controllers.API
{
    public class PositionController : BaseApiController<Position>
    {
        public PositionController()
            : base()
        {
        }

        public PositionController(IRepository<Position> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}