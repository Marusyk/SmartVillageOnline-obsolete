using Domain.Entities;
using Domain.Abstract;

namespace WebUI.Controllers.API
{
    public class NationalityController : BaseApiController<Nationality>
    {
        public NationalityController()
            : base()
        {
        }

        public NationalityController(IRepository<Nationality> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}