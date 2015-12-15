using Domain.Abstract;
using Domain.Entities.Dictionaries;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class NationalityController : BaseApiController<Nationality>
    {
        public NationalityController() { }

        public NationalityController(IRepository<Nationality> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}