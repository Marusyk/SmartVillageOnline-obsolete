using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using Domain.Entities.Dictionaries;
using WebUI.Controllers.API;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class CityTypeTests : BaseDictionaryTests<CityType>
    {
        public CityTypeTests()
            : base()
        {
            // get Mock Repository from base class
            var moq = base.CreateMockRepository();

            // create controller with Mock
            var controller = new CityTypeController(moq);

            // Init params of controller
            base.ArrangeController(controller);
        }

        [TestMethod]
        public void CityType_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void CityType_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void CityType_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void CityType_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void CityType_Can_Remove()
        {
            base.Remove();
        }
    }
}
