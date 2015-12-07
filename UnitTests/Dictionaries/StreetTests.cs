using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Controllers.API;
using Domain.Entities.Dictionaries;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public sealed class StreetTests : BaseEntityUnitTest<Street>
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
            ArrangeController(controller);
        }

        [TestMethod]
        public void Street_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void Street_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void Street_Can_Insert()
        {
            Insert();
        }

        [TestMethod]
        public void Street_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void Street_Can_Remove()
        {
            Remove();
        }
    }
}
