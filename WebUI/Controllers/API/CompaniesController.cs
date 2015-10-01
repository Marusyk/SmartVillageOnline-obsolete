using Domain.Abstract;
using Domain.Entities.Dictionaries;

namespace WebUI.Controllers.API
{
    public class CompaniesController : BaseApiController<Companies>
    {
        public CompaniesController()
            : base()
        {
        }

        public CompaniesController(IRepository<Companies> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}