using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities.Dictionaries;
using WebUI.Controllers.API;
using UnitTests.Infrastructure;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public sealed class DocumentTypeTests : BaseEntityUnitTest<DocumentType>
    {
        public DocumentTypeTests()
        {
            // get Mock Repository from base class
            var mockStorage = new MockStorage<DocumentType>();

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create controller with Mock
            var controller = new DocumentTypeController(moq);

            // Init params of controller
            ArrangeController(controller);
        }


        [TestMethod]
        public void DocumentType_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void DocumentType_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void DocumentType_Can_Insert()
        {
            Insert();
        }

        [TestMethod]
        public void DocumentType_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void DocumentType_Can_Remove()
        {
            Remove();
        }
    }
}
