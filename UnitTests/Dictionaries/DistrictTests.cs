using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Controllers.API;
using Domain.Entities.Dictionaries;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class DistrictTests : BaseEntityUnitTest<District>
    {
        public DistrictTests()
        {
            // get Mock Repository from base class
            var mockStorage = new MockStorage<District>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create controller with Mock
            var controller = new DistrictController(moq);

            // Init params of controller
            base.ArrangeController(controller);
        }

        [TestMethod]
        public void District_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void District_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void District_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void District_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void District_Can_Remove()
        {
            base.Remove();
        }
    }
}
