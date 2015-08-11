using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using WebUI.Controllers.API;
using UnitTests.Dictionaries;

namespace UnitTests
{
    [TestClass]
    public class CatalogTests : BaseDictionaryTests<Catalog>
    {
        public CatalogTests()
            : base()
        {
            // get Mock repository from base class
            var moq = base.CreateMockRepository();

            // create controller with Mock
            var controller = new CatalogController(moq);

            // Init params of controller
            base.ArrangeController(controller);
        }


        [TestMethod]
        public void Catalog_Get_All()
        {
            base.GetAll();
        }

        [TestMethod]
        public void Catalog_Get_By_Id()
        {
            base.GetById();
        }

        [TestMethod]
        public void Catalog_Can_Insert()
        {
            base.Insert();
        }

        [TestMethod]
        public void Catalog_Can_Edit()
        {
            base.Edit();
        }

        [TestMethod]
        public void Catalog_Can_Remove()
        {
            base.Remove();
        }
    }
}
