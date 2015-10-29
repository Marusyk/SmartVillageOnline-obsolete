using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using WebUI.Controllers.API;
using Domain.Entities.Dictionaries;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class ActivityTypesTests : BaseDictionaryTests<ActivityTypes>
    {
        public ActivityTypesTests()
            : base()
        {
            // get Mock repository from base class
            var moq = base.CreateMockRepository();

            // create controller with Mock
            var controller = new ActivityTypesController(moq);

            // Init params of controller
            base.ArrangeController(controller);
        }


        [TestMethod]
        public void ActivityTypes_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void ActivityTypes_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void ActivityTypes_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void ActivityTypes_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void ActivityTypes_Can_Remove()
        {
            base.Remove();
        }
    }
}
