using Domain.Entities.Dictionaries;
using Domain.Abstract;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class RegionController : BaseApiController<Region>
    {
        public RegionController() { }

        public RegionController(IRepository<Region> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}