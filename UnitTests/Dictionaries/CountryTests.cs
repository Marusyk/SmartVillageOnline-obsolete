using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities.Dictionaries;
using WebUI.Controllers.API;
using UnitTests.Infrastructure;

namespace UnitTests
{
    [TestClass]
    public class CountryTests : BaseEntityUnitTest<Country>
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
            base.ArrangeController(controller);
        }

        [TestMethod]
        public void Country_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void Country_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void Country_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void Country_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void Country_Can_Remove()
        {
            base.Remove();
        }
    }
}
