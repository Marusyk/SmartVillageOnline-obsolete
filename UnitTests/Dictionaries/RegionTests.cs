using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Controllers.API;
using Domain.Entities.Dictionaries;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class RegionTests : BaseDictionaryTests<Region>
    {
        public RegionTests()
            : base()
        {
            // get Mock Repository from base class
            var moq = base.CreateMockRepository();

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
