using Domain.Entities;
using Domain.Abstract;

namespace WebUI.Controllers.API
{
    public class DocumentTypeController : BaseApiController<DocumentType>
    {
        public DocumentTypeController()
            : base()
        {
        }

        public DocumentTypeController(IRepository<DocumentType> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}