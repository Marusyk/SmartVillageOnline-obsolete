using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Controllers.API;
using Domain.Entities.Dictionaries;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class StreetTypeTests : BaseEntityUnitTest<StreetType>
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
            base.ArrangeController(controller);
        }

        [TestMethod]
        public void StreetType_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void StreetType_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void StreetType_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void StreetType_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void StreetType_Can_Remove()
        {
            base.Remove();
        }
    }
}
