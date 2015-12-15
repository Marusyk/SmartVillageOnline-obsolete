using Domain.Abstract;
using Domain.Entities;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class EmploymentController : BaseApiController<Employment>
    {
        public EmploymentController(){ }
        
        public EmploymentController(IRepository<Employment> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}