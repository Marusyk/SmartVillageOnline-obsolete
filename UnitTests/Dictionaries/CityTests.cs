using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Controllers.API;
using Domain.Entities.Dictionaries;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class CityTests : BaseEntityUnitTest<City>
    {
        public CityTests()
        {
            // get Mock Repository from base class
            var mockStorage = new MockStorage<City>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

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

        [TestMethod]
        public void City_Get_All_Paging()
        {
            base.GetAll(/*pageNo, pageSize*/);
        }
    }
}
