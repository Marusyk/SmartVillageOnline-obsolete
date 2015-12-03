using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities.Dictionaries;
using WebUI.Controllers.API;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class FamilyRelationsTests : BaseEntityUnitTest<FamilyRelations>
    {
        public FamilyRelationsTests()
        {
            // get Mock Repository from base class
            var mockStorage = new MockStorage<FamilyRelations>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create controller with Mock
            var controller = new FamilyRelationsController(moq);

            // Init params of controller
            base.ArrangeController(controller);
        }


        [TestMethod]
        public void FamilyRelations_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void FamilyRelations_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void FamilyRelations_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void FamilyRelations_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void FamilyRelations_Can_Remove()
        {
            base.Remove();
        }
    }
}
