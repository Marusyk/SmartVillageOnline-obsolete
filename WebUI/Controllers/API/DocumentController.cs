using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers.API
{
    public class DocumentController : BaseApiController<Document>
    {
        public DocumentController() { }

        public DocumentController(IRepository<Document> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}