using Domain.Abstract;
using Domain.Entities.Dictionaries;

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