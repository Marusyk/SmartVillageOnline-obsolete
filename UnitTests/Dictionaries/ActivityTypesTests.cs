using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Controllers.API;
using Domain.Entities.Dictionaries;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public sealed class ActivityTypesTests : BaseEntityUnitTest<ActivityTypes>
    {
        public ActivityTypesTests()
        {
            // get Mock Repository from base class
            var mockStorage = new MockStorage<ActivityTypes>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create controller with Mock
            var controller = new ActivityTypesController(moq);

            // Init params of controller
            ArrangeController(controller);
        }


        [TestMethod]
        public void ActivityTypes_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void ActivityTypes_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void ActivityTypes_Can_Insert()
        {
            Insert();
        }

        [TestMethod]
        public void ActivityTypes_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void ActivityTypes_Can_Remove()
        {
            Remove();
        }
    }
}
