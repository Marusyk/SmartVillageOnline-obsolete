using Domain.Abstract;
using Domain.Entities;
using WebUI.Infrastructure;

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