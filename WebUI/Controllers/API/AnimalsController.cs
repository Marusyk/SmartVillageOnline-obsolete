using Domain.Entities;
using Domain.Abstract;


namespace WebUI.Controllers.API
{
    public class AnimalsController : BaseApiController<Animals>
    {
        public AnimalsController()
            : base()
        {
        }

        public AnimalsController(IRepository<Animals> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}
