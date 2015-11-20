using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Controllers.API;
using Domain.Entities;
using Domain.Entities.Dictionaries;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class StreetTypeTests : BaseDictionaryTests<StreetType>
    {
        public StreetTypeTests()
            : base()
        {
            // get Mock Repository from base class
            var moq = base.CreateMockRepository();

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
