using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using Domain.Entities.Dictionaries;
using WebUI.Controllers.API;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class PensionTypeTests : BaseDictionaryTests<PensionType>
    {
        public PensionTypeTests()
            : base()
        {
            // get Mock repository from base class
            var moq = base.CreateMockRepository();

            // create controller with Mock
            var controller = new PensionTypeController(moq);

            // Init params of controller
            base.ArrangeController(controller);
        }


        [TestMethod]
        public void PensionType_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void PensionType_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void PensionType_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void PensionType_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void PensionType_Can_Remove()
        {
            base.Remove();
        }
    }
}
