using Domain.Entities;
using Domain.Abstract;

namespace WebApi.Controllers.API
{
    public class CountryController : BaseApiController<Country>
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
