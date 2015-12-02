using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Abstract;
using Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebUI.Controllers.API;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using UnitTests.Infrastructure;

namespace UnitTests
{
    [TestClass]
    public class HouseTests : BaseEntityUnitTest<House>
    {
        public HouseTests()
        {
            // creating  fake Repository
            var persons = new List<House>
             {
                 new House {ID = 1, BuildNr = "01", HouseNr = "001" },
                 new House {ID = 2, BuildNr = "02", HouseNr = "002" },
                 new House {ID = 3, BuildNr = "03", HouseNr = "003" },
                 new House {ID = 4, BuildNr = "04", HouseNr = "004" },
                 new House {ID = 5, BuildNr = "05", HouseNr = "005" }
             };

            base.EntitiesList = persons;

            // get Mock Repository from base class
            var moq = base.CreateMockRepository();

            // create Controller with Mock
            var controller = new HouseController(moq);

            // Init params of Controller
            base.ArrangeController(controller);
        }

        [TestMethod]
        public void House_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void House_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void House_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void House_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void House_Can_Remove()
        {
            base.Remove();
        }
    }
}
