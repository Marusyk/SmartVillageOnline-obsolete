using Domain.Abstract;
using Domain.Entities.Dictionaries;

namespace WebUI.Controllers.API
{
    public class DocumentTypeController : BaseApiController<DocumentType>
    {
        public DocumentTypeController() { }

        public DocumentTypeController(IRepository<DocumentType> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}