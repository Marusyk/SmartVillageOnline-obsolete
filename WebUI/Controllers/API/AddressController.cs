using Domain.Entities;
using Domain.Abstract;

namespace WebUI.Controllers.API
{
    public class AddressController : BaseApiController<Address>
    {
        public AddressController()
            : base()
        {
        }

        public AddressController(IRepository<Address> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}