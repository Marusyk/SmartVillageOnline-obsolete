using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Abstract;
using Domain.Entities;
using System.Linq;
using WebUI.Controllers.API;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class AnimalsTests : BaseDictionaryTests<Animals>
    {
        public AnimalsTests()
            : base()
        {
            // get Mock repository from base class
            var moq = base.CreateMockRepository();

            // create controller with Mock
            var controller = new AnimalsController(moq);

            // Init params of controller
            base.ArrangeController(controller);
        }


        [TestMethod]
        public void Get_All_Animals()
        {
            base.GetAll();
        }

        [TestMethod]
        public void Animal_Can_Insert()
        {          
           base.Insert();
        }

        [TestMethod]
        public void Animal_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void Animal_Can_Remove()
        {
            base.Remove();
        }
    }
}
