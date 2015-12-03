using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities.Dictionaries;
using WebUI.Controllers.API;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class FamilyStatusTests : BaseEntityUnitTest<FamilyStatus>
    {
        public FamilyStatusTests()
        {
            // get Mock repository from base class
            var mockStorage = new MockStorage<FamilyStatus>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

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
