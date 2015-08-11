using Domain.Entities;
using Domain.Abstract;

namespace WebUI.Controllers.API
{
    public class CatalogController : BaseApiController<Catalog>
    {
        public CatalogController()
            : base()
        {
        }

        public CatalogController(IRepository<Catalog> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}