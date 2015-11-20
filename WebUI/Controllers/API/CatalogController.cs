using Domain.Entities;
using Domain.Abstract;

namespace WebUI.Controllers.API
{
    public class CatalogController : BaseApiController<Catalog>
    {
        public CatalogController() { }

        public CatalogController(IRepository<Catalog> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}