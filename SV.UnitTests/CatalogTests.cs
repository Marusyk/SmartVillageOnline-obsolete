using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using WebUI.Controllers.API;
using UnitTests.Infrastructure;

namespace UnitTests
{
    [TestClass]
    public sealed class CatalogTests : BaseEntityUnitTest<Catalog>
    {
        public CatalogTests()
        {
            // get Mock Repository from base class
            var mockStorage = new MockStorage<Catalog>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create controller with Mock
            var controller = new CatalogController(moq);

            // Init params of controller
            ArrangeController(controller);
        }


        [TestMethod]
        public void Catalog_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void Catalog_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void Catalog_Can_Insert()
        {
            Insert();
        }

        [TestMethod]
        public void Catalog_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void Catalog_Can_Remove()
        {
            Remove();
        }
    }
}
