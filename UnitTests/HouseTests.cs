using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Abstract;
using Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebUI.Controllers.API;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using UnitTests.Infrastructure;

namespace UnitTests
{
    [TestClass]
    public class HouseTests
    {
        #region private

        private IRepository<House> CreateMockRepository()
        {
            // creating  fake Repository
            var houses = new List<House>
            {
                new House {ID =1, HouseNr ="001", BuildNr ="1", Year = DateTime.Now.Year },
                new House {ID =2, HouseNr ="002", BuildNr= "2", Year = DateTime.Now.Year },
                new House {ID =3, HouseNr ="003", BuildNr ="3", Year = DateTime.Now.Year },
                new House {ID =4, HouseNr ="004", BuildNr ="4", Year = DateTime.Now.Year },
                new House {ID =5, HouseNr ="005", BuildNr ="5", Year = DateTime.Now.Year }
            };

            // configure the Mock Object
            Mock<IRepository<House>> mock = new Mock<IRepository<House>>();

            mock.Setup(m => m.All).Returns(houses.AsQueryable());

            mock.Setup(m => m.Add(It.IsAny<House>()))
                .Callback<House>(c => houses.Add(c));

            mock.Setup(m => m.Edit(It.IsAny<House>()))
                .Callback<House>(c => houses[houses.IndexOf(c)] = c);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns<int>(c => houses.Find(f => f.ID == c));

            mock.Setup(m => m.Delete(It.IsAny<House>()))
                .Callback<House>(c => houses.Remove(c));

            return mock.Object;
        }

        private HouseController ArrangeController()
        {
            // Get the mock Repository
            var moq = CreateMockRepository();
            var controller = new HouseController(moq);
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());
            return controller;
        }

        #endregion

        [TestMethod]
        public void House_Get_All()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            var response = target.Get();
            var result = response.ContentToQueryable<House>();

            //Assert
            Assert.AreEqual(5, result.Count());
        }

        [TestMethod]
        public void House_Get_By_Id()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            var result = GetByID(target, 1);

            //Assert
            Assert.AreEqual(1, result.ID);
        }

        [TestMethod]
        public void House_Can_Insert()
        {
            //Arrange
            var target = ArrangeController();

            //Arrange - create a new country for insert
            House newHouse = new House() { ID = 10, BuildNr = "010", HouseNr = "10" };

            //Action
            var resultInsert = target.Post(newHouse);
            var resultSelect = GetByID(target, 10);
            var resultTotalCount = target.Get().ContentToQueryable<House>();

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, resultInsert.StatusCode);
            Assert.AreEqual(10, resultSelect.ID);
            Assert.AreEqual(6, resultTotalCount.Count());
            Assert.AreEqual("010", resultSelect.BuildNr);
            Assert.AreEqual("10", resultSelect.HouseNr);
        }

        [TestMethod]
        public void House_Can_Edit()
        {
            //Arrange
            var target = ArrangeController();

            //Action                     
            var house = GetByID(target, 1);
            house.HouseNr = "007";
            var resultUpdate = target.Put(house);
            var resultSelect = GetByID(target, 1);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultUpdate.StatusCode);
            Assert.AreEqual(1, resultSelect.ID);
            Assert.AreEqual("007", resultSelect.HouseNr);
        }

        [TestMethod]
        public void House_Can_Remove()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            var house = GetByID(target, 1);
            var resultDelete = target.Delete(house.ID);
            var resultSelect = target.Get().ContentToQueryable<House>();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultDelete.StatusCode);
            Assert.AreEqual(4, resultSelect.Count());
        }

        private House GetByID(HouseController controller, int id)
        {
            return controller.GetById(id).ContentToEntity<House>();
        }
    }
}
