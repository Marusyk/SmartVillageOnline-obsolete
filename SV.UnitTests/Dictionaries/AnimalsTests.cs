using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities.Dictionaries;
using WebUI.Controllers.API;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public sealed class AnimalsTests : BaseEntityUnitTest<Animals>
    {
        public AnimalsTests()
        {
            // get Mock Repository from base class
            var mockStorage = new MockStorage<Animals>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create controller with Mock
            var controller = new AnimalsController(moq);

            // Init params of controller
            ArrangeController(controller);
        }


        [TestMethod]
        public void Animal_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void Animal_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void Animal_Can_Insert()
        {
            Insert();
        }

        [TestMethod]
        public void Animal_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void Animal_Can_Remove()
        {
            Remove();
        }
    }
}
