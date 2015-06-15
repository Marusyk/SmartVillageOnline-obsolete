using System.Web.Mvc;
using Domain.Abstract;

namespace WebUI.Controllers
{
    public class HouseController : Controller
    {
        IHouseRepository repository;

        public HouseController(IHouseRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult List()
        {
            return View(repository.House);
        }

    }
}
