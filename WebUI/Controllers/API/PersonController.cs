using Domain.Abstract;
using System.Linq;
using System.Net;
using System.Web.Http;
using Domain.Entities.Dictionaries;

namespace WebUI.Controllers.API
{
    public class PersonController : BaseApiController<Person>
    {
        public PersonController() { }

        public PersonController(IRepository<Person> repository)
            : base(repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public IQueryable<Person> GetByFirstName(string firstName)
        {
            var persons = Repository.FindBy(x => x.FirstName == firstName);

            if (!persons.Any())
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return persons;
        }
    }
}