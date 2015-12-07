using Domain.Entities.Dictionaries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Infrastructure;
using WebUI.Controllers.API;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public sealed class CountryTests : BaseEntityUnitTest<Country>
    {
        public CountryTests()
        {
            // get Mock Repository from base class
            var mockStorage = new MockStorage<Country>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create controller with Mock
            var controller = new CountryController(moq);

            // Init params of controller
            ArrangeController(controller);
        }

        [TestMethod]
        public void Country_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void Country_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void Country_Can_Insert()
        {
            Insert();
        }

        [TestMethod]
        public void Country_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void Country_Can_Remove()
        {
            Remove();
        }
    }
}
