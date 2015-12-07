using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Controllers.API;
using Domain.Entities.Dictionaries;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public sealed class RegionTests : BaseEntityUnitTest<Region>
    {
        public RegionTests()
        {
            // get Mock Repository from base class
            var mockStorage = new MockStorage<Region>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create controller with Mock
            var controller = new RegionController(moq);

            // Init params of controller
            ArrangeController(controller);
        }

        [TestMethod]
        public void Region_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void Region_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void Region_Can_Insert()
        {
            Insert();
        }

        [TestMethod]
        public void Region_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void Region_Can_Remove()
        {
            Remove();
        }
    }
}
