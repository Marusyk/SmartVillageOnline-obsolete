using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities.Dictionaries;
using WebUI.Controllers.API;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public sealed class PassAuthorityTests : BaseEntityUnitTest<PassAuthority>
    {
        public PassAuthorityTests()
        {
            // get Mock repository from base class
            var mockStorage = new MockStorage<PassAuthority>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create controller with Mock
            var controller = new PassAuthorityController(moq);

            // Init params of controller
            ArrangeController(controller);
        }


        [TestMethod]
        public void PassAuthority_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void PassAuthority_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void PassAuthority_Can_Insert()
        {
            Insert();
        }

        [TestMethod]
        public void PassAuthority_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void PassAuthority_Can_Remove()
        {
            Remove();
        }
    }
}
