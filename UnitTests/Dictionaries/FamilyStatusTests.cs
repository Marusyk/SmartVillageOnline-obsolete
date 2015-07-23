using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using WebUI.Controllers.API;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class FamilyStatusTests : BaseDictionaryTests<FamilyStatus>
    {
        public FamilyStatusTests()
            : base()
        {
            // get Mock repository from base class
            var moq = base.CreateMockRepository();

            // create controller with Mock
            var controller = new FamilyStatusController(moq);

            // Init params of controller
            base.ArrangeController(controller);
        }


        [TestMethod]
        public void FamilyStatus_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void FamilyStatus_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void FamilyStatus_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void FamilyStatus_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void FamilyStatus_Can_Remove()
        {
            base.Remove();
        }
    }
}
