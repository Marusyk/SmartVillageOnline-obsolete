using System.Collections.Generic;
using Domain.Entities.Dictionaries;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.Infrastructure;
using WebUI.Controllers.API;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public sealed class AddressTests : BaseEntityUnitTest<Address>
    {
        public AddressTests()
        {
            // creating  fake Repository
            var addresses = new List<Address>
            {
                new Address {ID = 1, BuildNr = "1" },
                new Address {ID = 2, BuildNr = "2" },
                new Address {ID = 3, BuildNr = "3" },
                new Address {ID = 4, BuildNr = "4" },
                new Address {ID = 5, BuildNr = "5" }
            };

            // get Mock Repository from base class
            var mockStorage = new MockStorage<Address>(addresses);

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create controller with Mock
            var controller = new AddressController(moq);

            // Init params of controller
            ArrangeController(controller);
        }        

        [TestMethod]
        public void Address_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void Address_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void Address_Can_Insert()
        {
            Insert();
        }

        [TestMethod]
        public void Address_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void Address_Can_Remove()
        {
            Remove();
        }
    }
}
