using Domain.Abstract;
using Domain.Entities.Dictionaries;

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
