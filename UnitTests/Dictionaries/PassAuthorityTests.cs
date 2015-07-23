using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using WebUI.Controllers.API;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class PassAuthorityTests : BaseDictionaryTests<PassAuthority>
    {
        public PassAuthorityTests()
            : base()
        {
            // get Mock repository from base class
            var moq = base.CreateMockRepository();

            // create controller with Mock
            var controller = new PassAuthorityController(moq);

            // Init params of controller
            base.ArrangeController(controller);
        }


        [TestMethod]
        public void PassAuthority_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void PassAuthority_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void PassAuthority_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void PassAuthority_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void PassAuthority_Can_Remove()
        {
            base.Remove();
        }
    }
}
