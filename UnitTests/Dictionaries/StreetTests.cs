using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Controllers.API;
using Domain.Entities.Dictionaries;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class StreetTests : BaseEntityUnitTest<Street>
    {
        public StreetTests()
        {
            // get Mock Repository from base class
            var mockStorage = new MockStorage<Street>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create controller with Mock
            var controller = new StreetController(moq);

            // Init params of controller
            base.ArrangeController(controller);
        }

        [TestMethod]
        public void Street_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void Street_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void Street_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void Street_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void Street_Can_Remove()
        {
            base.Remove();
        }
    }
}
