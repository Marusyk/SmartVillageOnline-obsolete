using Domain.Abstract;
using Domain.Entities.Dictionaries;

namespace WebUI.Controllers.API
{
    public class PositionController : BaseApiController<Position>
    {
        public PositionController() { }

        public PositionController(IRepository<Position> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}