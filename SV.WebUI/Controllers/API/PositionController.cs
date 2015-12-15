using Domain.Abstract;
using Domain.Entities.Dictionaries;
using WebUI.Infrastructure;

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