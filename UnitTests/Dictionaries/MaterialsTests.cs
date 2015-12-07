using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities.Dictionaries;
using WebUI.Controllers.API;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public sealed class MaterialsTests : BaseEntityUnitTest<Materials>
    {
        public MaterialsTests()
        {
            // get Mock Repository from base class
            var mockStorage = new MockStorage<Materials>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create controller with Mock
            var controller = new MaterialsController(moq);

            // Init params of controller
            ArrangeController(controller);
        }


        [TestMethod]
        public void Materials_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void Materials_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void Materials_Can_Insert()
        {
            Insert();
        }

        [TestMethod]
        public void Materials_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void Materials_Can_Remove()
        {
            Remove();
        }
    }
}
