using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers.API
{
    public class HouseController : ApiBaseController<House>
    {        

        public HouseController()
            : base()
        {            
        }

        public HouseController(IRepository<House> repository)
            : base(repository)
        {
            this.repository = repository;
        }       
    }
}
