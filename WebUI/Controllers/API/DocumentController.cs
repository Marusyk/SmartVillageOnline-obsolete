using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers.API
{
    public class DocumentController : BaseApiController<Document>
    {
        public DocumentController()
            : base()
        {
        }

        public DocumentController(IRepository<Document> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}