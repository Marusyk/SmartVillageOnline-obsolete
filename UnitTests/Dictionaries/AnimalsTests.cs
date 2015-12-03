using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities.Dictionaries;
using WebUI.Controllers.API;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class AnimalsTests : BaseEntityUnitTest<Animals>
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
            base.ArrangeController(controller);
        }


        [TestMethod]
        public void Animal_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void Animal_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void Animal_Can_Insert()
        {          
           base.Insert();
        }

        [TestMethod]
        public void Animal_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void Animal_Can_Remove()
        {
            base.Remove();
        }
    }
}
