using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Abstract;
using Domain.Entities;
using System.Linq;
using WebUI.Controllers.API;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Collections.Generic;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class CityTypeTests : BaseDictionaryTests<CityType>
    {
        public CityTypeTests()
            : base()
        {
            // get Mock repository from base class
            var moq = base.CreateMockRepository();

            // create controller with Mock
            var controller = new CityTypeController(moq);

            // Init params of controller
            base.ArrangeController(controller);
        }

        [TestMethod]
        public void CityTypes_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void CityTypes_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void CityTypes_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void CityTypes_Can_Remove()
        {
            base.Remove();
        }
    }
}
