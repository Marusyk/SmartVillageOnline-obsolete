using Domain.Entities;
using Domain.Abstract;

namespace WebUI.Controllers.API
{
    public class PassAuthorityController : BaseApiController<PassAuthority>
    {
        public PassAuthorityController()
            : base()
        {
        }

        public PassAuthorityController(IRepository<PassAuthority> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}