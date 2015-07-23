using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using WebUI.Controllers.API;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class FamilyRelationsTests : BaseDictionaryTests<FamilyRelations>
    {
        public FamilyRelationsTests()
            : base()
        {
            // get Mock repository from base class
            var moq = base.CreateMockRepository();

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
