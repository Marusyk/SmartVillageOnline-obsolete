using Domain.Entities;
using Domain.Abstract;

namespace WebUI.Controllers.API
{
    public class CountryController : ApiBaseController<Country>
    {
        public CountryController()
            : base()
        {           
        }

        public CountryController(IRepository<Country> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}
