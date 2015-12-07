using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities.Dictionaries;
using WebUI.Controllers.API;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public sealed class NationalityTests : BaseEntityUnitTest<Nationality>
    {
        public NationalityTests()
        {
            // get Mock Repository from base class
            var mockStorage = new MockStorage<Nationality>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create controller with Mock
            var controller = new NationalityController(moq);

            // Init params of controller
            ArrangeController(controller);
        }


        [TestMethod]
        public void Nationality_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void Nationality_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void Nationality_Can_Insert()
        {
            Insert();
        }

        [TestMethod]
        public void Nationality_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void Nationality_Can_Remove()
        {
            Remove();
        }
    }
}
