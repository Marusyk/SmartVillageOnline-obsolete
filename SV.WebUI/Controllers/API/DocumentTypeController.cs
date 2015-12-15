using Domain.Abstract;
using Domain.Entities.Dictionaries;
using WebUI.Infrastructure;

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