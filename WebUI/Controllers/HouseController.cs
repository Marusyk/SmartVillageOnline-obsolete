using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Abstract;
using Domain.Entities;

namespace WebUI.Controllers
{
    public class HouseController : Controller
    {
        IHouseRepository repository;

        public HouseController(IHouseRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            return View(repository.House);
        }

    }
}
