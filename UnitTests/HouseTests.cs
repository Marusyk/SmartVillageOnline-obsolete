using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebUI.Controllers.API;
using UnitTests.Infrastructure;

namespace UnitTests
{
    [TestClass]
    public sealed class HouseTests : BaseEntityUnitTest<House>
    {
        public HouseTests()
        {
            // creating  fake Repository
            var houses = new List<House>
             {
                 new House {ID = 1, BuildNr = "01", HouseNr = "001", Year = 2015 },
                 new House {ID = 2, BuildNr = "02", HouseNr = "002", Year = 2015 },
                 new House {ID = 3, BuildNr = "03", HouseNr = "003", Year = 2015 },
                 new House {ID = 4, BuildNr = "04", HouseNr = "004", Year = 2015 },
                 new House {ID = 5, BuildNr = "05", HouseNr = "005", Year = 2015 }
             };

            // create a mock storage and pass list of houses
            var mockStorage = new MockStorage<House>(houses); 
            // default setup
            mockStorage.SetupMock();
            // Here is a bit black magic. We need to configure FindBy method because House.Get() used FindBy by default           
            mockStorage.SetupFindBy(x1 => x1.FindBy(x2 => x2.Year == DateTime.Now.Year), x => x.Year == DateTime.Now.Year);

            // get Mock Repository
            var moq = mockStorage.ReturnMock();
            //mockStorage.SetupFindBy(x => x.ID == 1);

            // create Controller with Mock
            var controller = new HouseController(moq);

            // Init params of Controller
            ArrangeController(controller);
        }

        [TestMethod]
        public void House_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void House_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void House_Can_Insert()
        {
            // Arrange
            const int idValue = 10;
            var entity = new House() { ID = idValue, LastUpdUS = "TEST", Year = DateTime.Now.Year};

            // Act
            var totalCountBefore = Controller.Get().ContentToQueryable<House>().Count();
            var resultInsert = Controller.Post(entity);
            var resultSelect = Controller.GetById(idValue).ContentToEntity<House>();
            var totalCountAfter = Controller.Get().ContentToQueryable<House>().Count();

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, resultInsert.StatusCode);
            Assert.AreEqual(idValue, resultSelect.ID);
            Assert.AreEqual(totalCountBefore + 1, totalCountAfter);
            Assert.AreEqual("TEST", resultSelect.LastUpdUS);
        }

        [TestMethod]
        public void House_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void House_Can_Remove()
        {
            Remove();
        }
    }
}
