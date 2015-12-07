using Domain.Abstract;
using Domain.Entities.Dictionaries;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class CountryController : BaseApiController<Country>
    {
        public CountryController() { }

        public CountryController(IRepository<Country> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}
