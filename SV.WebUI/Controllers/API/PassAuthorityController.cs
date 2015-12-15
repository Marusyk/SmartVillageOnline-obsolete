using Domain.Abstract;
using Domain.Entities.Dictionaries;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class PassAuthorityController : BaseApiController<PassAuthority>
    {
        public PassAuthorityController() { }

        public PassAuthorityController(IRepository<PassAuthority> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}