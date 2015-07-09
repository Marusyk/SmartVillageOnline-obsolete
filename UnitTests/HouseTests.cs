using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Abstract;
using Domain.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebUI.Controllers.API;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http;
using System.Net;

namespace UnitTests
{
    [TestClass]
    public class HouseTests
    {
        #region private

        private readonly string MainUri = "http://localhost/api/house";

        private IRepository<House> CreateMockRepository()
        {
            // creating  fake repository
            var houses = new List<House>
            {
                new House {ID =1, HouseNr ="001", BuildNr ="1"},
                new House {ID =2, HouseNr ="002", BuildNr= "2" },
                new House {ID =3, HouseNr ="003", BuildNr ="3" },
                new House {ID =4, HouseNr ="004", BuildNr ="4"},
                new House {ID =5, HouseNr ="005", BuildNr ="5" }
            };

            // configure the Mock Object
            Mock<IRepository<House>> mock = new Mock<IRepository<House>>();

            mock.Setup(m => m.Table).Returns(houses.AsQueryable());

            mock.Setup(m => m.Insert(It.IsAny<House>()))
                .Callback<House>(c => houses.Add(c));

            mock.Setup(m => m.Update(It.IsAny<House>()))
                .Callback<House>(c => houses[houses.IndexOf(c)] = c);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns<int>(c => houses.Find(f => f.ID == c));

            mock.Setup(m => m.Delete(It.IsAny<House>()))
                .Callback<House>(c => houses.Remove(c));

            return mock.Object;
        }

        #endregion

        [TestMethod]
        public void Get_All_Houses()
        {
            //Arrange - create mock repository               
            var moq = CreateMockRepository();

            //Arrange - create a controller
            HouseController target = new HouseController(moq);

            //Action
            var result = target.Get().ToArray();

            //Assert
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void Can_Insert_House()
        {
            //Arrange - get the mock repository               
            var moq = CreateMockRepository();

            //Arrange - create and configure controller            
            var request = new HttpRequestMessage(HttpMethod.Post, MainUri);

            HouseController target = new HouseController(moq);

            target.ControllerContext = new HttpControllerContext() { Request = request };
            target.Request = request;
            target.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = new HttpConfiguration();

            //Arrange - create a new country for insert
            House newHouse = new House() { ID = 10, BuildNr = "010", HouseNr = "10" };

            //Action
            var resultInsert = target.Post(newHouse);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(6, resultSelect.Length);
            Assert.AreEqual(HttpStatusCode.Created, resultInsert.StatusCode);
        }

        [TestMethod]
        public void Can_Edit_House()
        {
            //Arrange - get the mock repository
            var moq = CreateMockRepository();

            //Arrange - create and configure controller                        
            var request = new HttpRequestMessage(HttpMethod.Put, MainUri);

            HouseController target = new HouseController(moq);

            target.ControllerContext = new HttpControllerContext() { Request = request };
            target.Request = request;
            target.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = new HttpConfiguration(); ;

            //Action                     
            var house = target.GetById(1);
            house.HouseNr = "007";
            var resultUpdate = target.Put(house);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultUpdate.StatusCode);
            Assert.AreEqual("007", resultSelect[0].HouseNr);
        }

        [TestMethod]
        public void Can_Remove_House()
        {
            //Arrange - get the mock repository
            var moq = CreateMockRepository();

            //Arrange - create and configure controller                      
            var request = new HttpRequestMessage(HttpMethod.Delete, MainUri);

            HouseController target = new HouseController(moq);

            target.ControllerContext = new HttpControllerContext() { Request = request };
            target.Request = request;
            target.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = new HttpConfiguration(); ;

            //Action
            var house = target.GetById(1);
            var resultDelete = target.Delete(house.ID);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultDelete.StatusCode);
            Assert.AreEqual(4, resultSelect.Length);
        }
    }
}
