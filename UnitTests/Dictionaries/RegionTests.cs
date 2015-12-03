using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Controllers.API;
using Domain.Entities.Dictionaries;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class RegionTests : BaseEntityUnitTest<Region>
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
            base.ArrangeController(controller);
        }

        [TestMethod]
        public void Region_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void Region_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void Region_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void Region_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void Region_Can_Remove()
        {
            base.Remove();
        }
    }
}
