using Domain.Entities;
using Domain.Abstract;
using System.Net.Http;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace WebUI.Controllers.API
{
    public class StreetController : BaseApiController<Street>
    {
        public StreetController()
            : base()
        {
        }

        public StreetController(IRepository<Street> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}
