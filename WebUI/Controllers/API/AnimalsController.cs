using Domain.Abstract;
using Domain.Entities.Dictionaries;
using WebUI.Infrastructure;


namespace WebUI.Controllers.API
{
    public class AnimalsController : BaseApiController<Animals>
    {
        public AnimalsController() { }

        public AnimalsController(IRepository<Animals> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}
