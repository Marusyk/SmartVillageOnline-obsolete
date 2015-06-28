using Domain.Abstract;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using Microsoft.Data.OData;

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

        [HttpGet]
        [Queryable]
        public IQueryable<House> GetByYear(int year)
        {
            //var houses = repository.Table.ToList();

            //if (houses == null)
            //{
            //    throw new HttpResponseException(HttpStatusCode.NoContent);
            //}
            var houses = base.GetById(1);

            return houses as IQueryable<House>;
        }
    }
}
