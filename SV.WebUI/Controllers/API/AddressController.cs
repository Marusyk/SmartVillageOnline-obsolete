using Domain.Abstract;
using Domain.Entities.Dictionaries;
using WebUI.Infrastructure;

namespace WebUI.Controllers.API
{
    public class AddressController : BaseApiController<Address>
    {
        public AddressController() { }

        public AddressController(IRepository<Address> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}