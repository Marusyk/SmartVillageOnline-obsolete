using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities.Dictionaries;
using WebUI.Controllers.API;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public sealed class PositionTests : BaseEntityUnitTest<Position>
    {
        public PositionTests()
        {
            // get Mock Repository from base class
            var mockStorage = new MockStorage<Position>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create controller with Mock
            var controller = new PositionController(moq);

            // Init params of controller
            ArrangeController(controller);
        }


        [TestMethod]
        public void Position_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void Position_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void Position_Can_Insert()
        {
            Insert();
        }

        [TestMethod]
        public void Position_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void Position_Can_Remove()
        {
            Remove();
        }
    }
}
