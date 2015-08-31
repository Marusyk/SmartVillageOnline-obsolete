using Domain.Abstract;
using Domain.Entities;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.OData;

namespace WebUI.Controllers.API
{
    public class PeopleController : BaseApiController<People>
    {
        public PeopleController()
            : base()
        {
        }

        public PeopleController(IRepository<People> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}
