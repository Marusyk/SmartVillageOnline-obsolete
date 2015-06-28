using Domain.Abstract;
using Domain.Entities.SystemTables;

namespace WebUI.Controllers.API
{
    public class DictionaryController : ApiBaseController<SYS_Dictionary>
    {

        public DictionaryController()
            : base()
        {            
        }

        public DictionaryController(IRepository<SYS_Dictionary> repository)
            : base(repository)
        {
            this.repository = repository;
        }
    }
}
