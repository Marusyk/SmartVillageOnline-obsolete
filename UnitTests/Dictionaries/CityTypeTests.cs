using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Abstract;
using Domain.Entities;
using System.Linq;
using WebApi.Controllers.API;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using System.Collections.Generic;

namespace UnitTests.Dictionaries
{
    /// <summary>
    /// Summary description for CityTypeTests
    /// </summary>
    [TestClass]
    public class CityTypeTests
    {       
        #region private

        private readonly string MainUri = "http://localhost/api/citytype";

        private IRepository<CityType> CreateMockRepository()
        {
            // creating  fake repository
            var types = new List<CityType>
            {
                new CityType {ID =1, Name ="CityType1" },
                new CityType {ID =2, Name ="CityType2" },
                new CityType {ID =3, Name ="CityType3" },
                new CityType {ID =4, Name ="CityType4" },
                new CityType {ID =5, Name ="CityType5" }
            };

            // configure the Mock Object
            Mock<IRepository<CityType>> mock = new Mock<IRepository<CityType>>();

            mock.Setup(m => m.Table).Returns(types.AsQueryable());

            mock.Setup(m => m.Insert(It.IsAny<CityType>()))
                .Callback<CityType>(c => types.Add(c));

            mock.Setup(m => m.Update(It.IsAny<CityType>()))
                .Callback<CityType>(c => types[types.IndexOf(c)] = c);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns<int>(c => types.Find(f => f.ID == c));

            mock.Setup(m => m.Delete(It.IsAny<CityType>()))
                .Callback<CityType>(c => types.Remove(c));

            return mock.Object;
        }

        #endregion

        [TestMethod]
        public void Get_All_CityTypes()
        {
            //Arrange - create mock repository               
            var moq = CreateMockRepository();

            //Arrange - create a controller
            CityTypeController target = new CityTypeController(moq);

            //Action
            var result = target.Get().ToArray();

            //Assert
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void Can_Insert_CityType()
        {
            //Arrange - get the mock repository               
            var moq = CreateMockRepository();

            //Arrange - create and configure controller            
            var request = new HttpRequestMessage(HttpMethod.Post, MainUri);

            CityTypeController target = new CityTypeController(moq);

            target.ControllerContext = new HttpControllerContext() { Request = request };
            target.Request = request;
            target.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = new HttpConfiguration();

            //Arrange - create a new country for insert
            var newType = new CityType() { ID = 10, Name = "TEST" };

            //Action
            var resultInsert = target.Post(newType);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(6, resultSelect.Length);
            Assert.AreEqual(HttpStatusCode.Created, resultInsert.StatusCode);
        }

        [TestMethod]
        public void Can_Edit_CityType()
        {
            //Arrange - get the mock repository
            var moq = CreateMockRepository();

            //Arrange - create and configure controller                        
            var request = new HttpRequestMessage(HttpMethod.Put, MainUri);

            var target = new CityTypeController(moq);

            target.ControllerContext = new HttpControllerContext() { Request = request };
            target.Request = request;
            target.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = new HttpConfiguration(); ;

            //Action                     
            var type = target.GetById(1);
            type.Name = "TEST";
            var resultUpdate = target.Put(type);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultUpdate.StatusCode);
            Assert.AreEqual("TEST", resultSelect[0].Name);
        }

        [TestMethod]
        public void Can_Remove_CityType()
        {
            //Arrange - get the mock repository
            var moq = CreateMockRepository();

            //Arrange - create and configure controller                      
            var request = new HttpRequestMessage(HttpMethod.Delete, MainUri);

            var target = new CityTypeController(moq);

            target.ControllerContext = new HttpControllerContext() { Request = request };
            target.Request = request;
            target.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = new HttpConfiguration(); ;

            //Action
            var type = target.GetById(1);
            var resultDelete = target.Delete(type.ID);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultDelete.StatusCode);
            Assert.AreEqual(4, resultSelect.Length);
        }
    }
}
