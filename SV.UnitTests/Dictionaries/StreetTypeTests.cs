using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Controllers.API;
using Domain.Entities.Dictionaries;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public sealed class StreetTypeTests : BaseEntityUnitTest<StreetType>
    {
        public StreetTypeTests()
            : base()
        {
            // get Mock Repository from base class
            var mockStorage = new MockStorage<StreetType>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create controller with Mock
            var controller = new StreetTypeController(moq);

            // Init params of controller
            ArrangeController(controller);
        }

        [TestMethod]
        public void StreetType_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void StreetType_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void StreetType_Can_Insert()
        {
            Insert();
        }

        [TestMethod]
        public void StreetType_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void StreetType_Can_Remove()
        {
            Remove();
        }
    }
}
