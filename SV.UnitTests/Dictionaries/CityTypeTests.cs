using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities.Dictionaries;
using WebUI.Controllers.API;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public sealed class CityTypeTests : BaseEntityUnitTest<CityType>
    {
        public CityTypeTests()
        {
            // get Mock Repository from base class
            var mockStorage = new MockStorage<CityType>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create controller with Mock
            var controller = new CityTypeController(moq);

            // Init params of controller
            ArrangeController(controller);
        }

        [TestMethod]
        public void CityType_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void CityType_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void CityType_Can_Insert()
        {
            Insert();
        }

        [TestMethod]
        public void CityType_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void CityType_Can_Remove()
        {
            Remove();
        }
    }
}
