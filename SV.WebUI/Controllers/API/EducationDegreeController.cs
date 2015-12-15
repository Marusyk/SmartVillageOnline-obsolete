using Domain.Abstract;
using Domain.Entities.Dictionaries;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class EducationDegreeController : BaseApiController<EducationDegree>
    {
        public EducationDegreeController() { }

        public EducationDegreeController(IRepository<EducationDegree> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}