using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using Domain.Entities.Dictionaries;
using WebUI.Controllers.API;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class NationalityTests : BaseDictionaryTests<Nationality>
    {
        public NationalityTests()
            : base()
        {
            // get Mock Repository from base class
            var moq = base.CreateMockRepository();

            // create controller with Mock
            var controller = new NationalityController(moq);

            // Init params of controller
            base.ArrangeController(controller);
        }


        [TestMethod]
        public void Nationality_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void Nationality_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void Nationality_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void Nationality_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void Nationality_Can_Remove()
        {
            base.Remove();
        }
    }
}
