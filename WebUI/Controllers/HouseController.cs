using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;
using Domain.Concrete;
using Domain;
using System.Collections.Generic;
using System.Linq;

namespace WebUI.Controllers
{
    public class HouseController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private EFRepository<Country> repository;

        public HouseController()
        {
            repository = unitOfWork.EFRepository<Country>();
        }

        public ActionResult List()
        {
            IEnumerable<Country> country = repository.Table.ToList();
            return View(country);
        }

    }
}
