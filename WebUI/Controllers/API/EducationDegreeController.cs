using Domain.Abstract;
using Domain.Entities.Dictionaries;

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