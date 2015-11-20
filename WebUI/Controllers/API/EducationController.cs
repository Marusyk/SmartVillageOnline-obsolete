using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers.API
{
    public class EducationController : BaseApiController<Education>
    {
        public EducationController() { }

        public EducationController(IRepository<Education> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}