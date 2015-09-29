using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers.API
{
    public class PersonDocumentsController : BaseApiController<PersonDocuments>
    {
        public PersonDocumentsController()
            : base()
        {
        }

        public PersonDocumentsController(IRepository<PersonDocuments> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}