using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using WebUI.Controllers.API;
using UnitTests.Dictionaries;
using Domain.Abstract;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using Moq;
using System.Linq;
using System.Net;

namespace UnitTests
{
    [TestClass]
    public class AddressTests
    {
        #region private

        private IRepository<Address> CreateMockRepository()
        {
            // creating  fake repository
            var addresses = new List<Address>
            {
                new Address {ID = 1, BuildNr = "1" },
                new Address {ID = 2, BuildNr = "2" },
                new Address {ID = 3, BuildNr = "3" },
                new Address {ID = 4, BuildNr = "4" },
                new Address {ID = 5, BuildNr = "5" }
            };

            // configure the Mock Object
            Mock<IRepository<Address>> mock = new Mock<IRepository<Address>>();

            mock.Setup(m => m.Table).Returns(addresses.AsQueryable());

            mock.Setup(m => m.Insert(It.IsAny<Address>()))
                .Callback<Address>(c => addresses.Add(c));

            mock.Setup(m => m.Update(It.IsAny<Address>()))
                .Callback<Address>(c => addresses[addresses.IndexOf(c)] = c);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns<int>(c => addresses.Find(f => f.ID == c));

            mock.Setup(m => m.Delete(It.IsAny<Address>()))
                .Callback<Address>(c => addresses.Remove(c));

            return mock.Object;
        }

        private AddressController ArrangeController()
        {
            // Get the mock repository
            var moq = CreateMockRepository();
            var controller = new AddressController(moq);
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());
            return controller;
        }

        #endregion

        [TestMethod]
        public void Address_Get_All()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            var result = target.Get().ToArray();

            //Assert
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void Address_Can_Insert()
        {
            //Arrange
            var target = ArrangeController();

            //Arrange - create a new country for insert
            Address newAddress = new Address() { ID = 10, BuildNr = "010" };

            //Action
            var resultInsert = target.Post(newAddress);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(6, resultSelect.Length);
            Assert.AreEqual(HttpStatusCode.Created, resultInsert.StatusCode);
        }

        [TestMethod]
        public void Address_Can_Edit()
        {
            //Arrange
            var target = ArrangeController();

            //Action                     
            var address = target.GetById(1);
            address.BuildNr = "007";
            var resultUpdate = target.Put(address);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultUpdate.StatusCode);
            Assert.AreEqual("007", resultSelect[0].BuildNr);
        }

        [TestMethod]
        public void Address_Can_Remove()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            var address = target.GetById(1);
            var resultDelete = target.Delete(address.ID);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultDelete.StatusCode);
            Assert.AreEqual(4, resultSelect.Length);
        }
    }
}
