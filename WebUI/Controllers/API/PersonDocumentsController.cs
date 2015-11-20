using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers.API
{
    public class PersonDocumentsController : BaseApiController<PersonDocuments>
    {
        public PersonDocumentsController() { }

        public PersonDocumentsController(IRepository<PersonDocuments> repository)
            : base(repository)
        {
            Repository = repository;
        }
    }
}