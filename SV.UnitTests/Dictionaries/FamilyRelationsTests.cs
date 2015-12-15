using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities.Dictionaries;
using WebUI.Controllers.API;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public sealed class FamilyRelationsTests : BaseEntityUnitTest<FamilyRelations>
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
            ArrangeController(controller);
        }


        [TestMethod]
        public void FamilyRelations_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void FamilyRelations_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void FamilyRelations_Can_Insert()
        {
            Insert();
        }

        [TestMethod]
        public void FamilyRelations_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void FamilyRelations_Can_Remove()
        {
            Remove();
        }
    }
}
