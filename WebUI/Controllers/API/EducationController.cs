using Domain.Abstract;
using Domain.Entities.Dictionaries;

namespace WebUI.Controllers.API
{
    public class EducationController : BaseApiController<Education>
    {
        public EducationController()
            : base()
        {
        }

        public EducationController(IRepository<Education> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}