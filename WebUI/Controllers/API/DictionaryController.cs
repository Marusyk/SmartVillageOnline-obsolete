using Domain;
using Domain.Abstract;
using Domain.Entities.SystemTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebUI.Controllers.API
{
    public class DictionaryController : ApiController
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private IRepository<SYS_Dictionary> repository;

        public DictionaryController()
        {
            repository = unitOfWork.EFRepository<SYS_Dictionary>();
        }

        public DictionaryController(IRepository<SYS_Dictionary> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<SYS_Dictionary> Get()
        {
            return repository.Table.ToList();
        }

    }
}
