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
using UnitTests.Dictionaries;

namespace UnitTests
{
    [TestClass]
    public class CountryTests : BaseDictionaryTests<Country>
    {
        public CountryTests()
            : base()
        {
            // get Mock repository from base class
            var moq = base.CreateMockRepository();

            // create controller with Mock
            var controller = new CountryController(moq);

            // Init params of controller
            base.ArrangeController(controller);
        }

        [TestMethod]
        public void Country_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void Country_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void Country_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void Country_Can_Remove()
        {
            base.Remove();
        }
    }
}
