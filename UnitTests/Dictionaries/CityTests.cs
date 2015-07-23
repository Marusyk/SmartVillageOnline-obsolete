using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Controllers.API;
using Domain.Entities.Dictionaries;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class CityTests : BaseDictionaryTests<City>
    {
        public CityTests()
            : base()
        {
            // get Mock repository from base class
            var moq = base.CreateMockRepository();

            // create controller with Mock
            var controller = new CityController(moq);

            // Init params of controller
            base.ArrangeController(controller);
        }

        [TestMethod]
        public void City_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void City_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void City_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void City_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void City_Can_Remove()
        {
            base.Remove();
        }
    }
}
