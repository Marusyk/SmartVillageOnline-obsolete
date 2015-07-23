using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebUI.Controllers.API;
using Domain.Entities.Dictionaries;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class DistrictTests : BaseDictionaryTests<District>
    {
        public DistrictTests()
            : base()
        {
            // get Mock repository from base class
            var moq = base.CreateMockRepository();

            // create controller with Mock
            var controller = new DistrictController(moq);

            // Init params of controller
            base.ArrangeController(controller);
        }

        [TestMethod]
        public void District_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void District_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void District_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void District_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void District_Can_Remove()
        {
            base.Remove();
        }
    }
}
