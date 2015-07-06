using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Abstract;
using Domain.Entities;
using System.Linq;
using WebUI.Controllers.API;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Collections.Generic;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class AnimalsTests
    {
        #region private

        private readonly string MainUri = "http://localhost/api/animals";

        private IRepository<Animals> CreateMockRepository()
        {
            // creating  fake repository
            var animals = new List<Animals>
            {
                new Animals {ID =1, Name ="Animal1" },
                new Animals {ID =2, Name ="Animal2" },
                new Animals {ID =3, Name ="Animal3" },
                new Animals {ID =4, Name ="Animal4" },
                new Animals {ID =5, Name ="Animal5" }
            };

            // configure the Mock Object
            Mock<IRepository<Animals>> mock = new Mock<IRepository<Animals>>();

            mock.Setup(m => m.Table).Returns(animals.AsQueryable());

            mock.Setup(m => m.Insert(It.IsAny<Animals>()))
                .Callback<Animals>(c => animals.Add(c));

            mock.Setup(m => m.Update(It.IsAny<Animals>()))
                .Callback<Animals>(c => animals[animals.IndexOf(c)] = c);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns<int>(c => animals.Find(f => f.ID == c));

            mock.Setup(m => m.Delete(It.IsAny<Animals>()))
                .Callback<Animals>(c => animals.Remove(c));

            return mock.Object;
        }

        #endregion

        [TestMethod]
        public void Get_All_Animals()
        {
            //Arrange - create mock repository               
            var moq = CreateMockRepository();

            //Arrange - create a controller
            AnimalsController target = new AnimalsController(moq);

            //Action
            var result = target.Get().ToArray();

            //Assert
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void Can_Insert_Animal()
        {
            //Arrange - get the mock repository               
            var moq = CreateMockRepository();

            //Arrange - create and configure controller            
            var request = new HttpRequestMessage(HttpMethod.Post, MainUri);

            AnimalsController target = new AnimalsController(moq);

            target.ControllerContext = new HttpControllerContext() { Request = request };
            target.Request = request;
            target.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = new HttpConfiguration();

            //Arrange - create a new country for insert
            Animals newAnimal = new Animals() { ID = 10, Name = "TEST" };

            //Action
            var resultInsert = target.Post(newAnimal);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(6, resultSelect.Length);
            Assert.AreEqual(HttpStatusCode.Created, resultInsert.StatusCode);
        }

        [TestMethod]
        public void Can_Edit_Animal()
        {
            //Arrange - get the mock repository
            var moq = CreateMockRepository();

            //Arrange - create and configure controller                        
            var request = new HttpRequestMessage(HttpMethod.Put, MainUri);

            AnimalsController target = new AnimalsController(moq);

            target.ControllerContext = new HttpControllerContext() { Request = request };
            target.Request = request;
            target.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = new HttpConfiguration(); ;

            //Action                     
            var animal = target.GetById(1);
            animal.Name = "TEST";
            var resultUpdate = target.Put(animal);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultUpdate.StatusCode);
            Assert.AreEqual("TEST", resultSelect[0].Name);
        }

        [TestMethod]
        public void Can_Remove_Animal()
        {
            //Arrange - get the mock repository
            var moq = CreateMockRepository();

            //Arrange - create and configure controller                      
            var request = new HttpRequestMessage(HttpMethod.Delete, MainUri);

            AnimalsController target = new AnimalsController(moq);

            target.ControllerContext = new HttpControllerContext() { Request = request };
            target.Request = request;
            target.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = new HttpConfiguration(); ;

            //Action
            var animal = target.GetById(1);
            var resultDelete = target.Delete(animal.ID);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultDelete.StatusCode);
            Assert.AreEqual(4, resultSelect.Length);
        }
    }
}
