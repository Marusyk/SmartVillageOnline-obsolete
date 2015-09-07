﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
            HttpResponseMessage response = target.Get();
            var result = response.Content.ReadAsAsync<IQueryable<Address>>().Result;

            //Assert
            Assert.AreEqual(5, result.Count());
        }

        [TestMethod]
        public void Address_Get_By_Id()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            HttpResponseMessage response = target.GetById(1);
            var result = response.Content.ReadAsAsync<Address>().Result;

            //Assert
            Assert.AreEqual(1, result.ID);
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
            var resultSelect = target.GetById(10).Content.ReadAsAsync<Address>().Result;
            var resultTotalCount = target.Get().Content.ReadAsAsync<IQueryable<Address>>().Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, resultInsert.StatusCode);
            Assert.AreEqual(10, resultSelect.ID);
            Assert.AreEqual(6, resultTotalCount.Count());
            Assert.AreEqual("010", resultSelect.BuildNr);
        }

        [TestMethod]
        public void Address_Can_Edit()
        {
            //Arrange
            var target = ArrangeController();

            //Action                     
            var address = target.GetById(1).Content.ReadAsAsync<Address>().Result;
            address.BuildNr = "007";
            var resultUpdate = target.Put(address);
            var resultSelect = target.GetById(1).Content.ReadAsAsync<Address>().Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultUpdate.StatusCode);
            Assert.AreEqual(1, resultSelect.ID);
            Assert.AreEqual("007", resultSelect.BuildNr);
        }

        [TestMethod]
        public void Address_Can_Remove()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            var address = target.GetById(1).Content.ReadAsAsync<Address>().Result;
            var resultDelete = target.Delete(address.ID);
            var resultSelect = target.Get().Content.ReadAsAsync<IQueryable<Address>>().Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultDelete.StatusCode);
            Assert.AreEqual(4, resultSelect.Count());
        }
    }
}