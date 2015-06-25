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

namespace UnitTests
{
    [TestClass]
    public class CountryTests
    {
        #region private

        private IRepository<Country> CreateMockRepository()
        {
            // --
            // Configure the Mock Object

            var countries = new List<Country>
            {
                new Country {ID =1, Name ="Country1" },
                new Country {ID =2, Name ="Country2" },
                new Country {ID =3, Name ="Country3" },
                new Country {ID =4, Name ="Country4" },
                new Country {ID =5, Name ="Country5" }
            };

            Mock<IRepository<Country>> mock = new Mock<IRepository<Country>>();

            mock.Setup(m => m.Table).Returns(countries.AsQueryable());

            mock.Setup(m => m.Insert(It.IsAny<Country>()))
                .Callback<Country>(c => countries.Add(c));

            mock.Setup(m => m.Update(It.IsAny<Country>()))
                .Callback<Country>(c => countries[countries.IndexOf(c)] = c);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns<int>(c => countries.Find(f => f.ID == c));

            mock.Setup(m => m.Delete(It.IsAny<Country>()))
                .Callback<Country>(c => countries.Remove(c));

            return mock.Object;
        }

        #endregion

        [TestMethod]
        public void Get_All_Country()
        {
            //Arrange - create mock repository               
            var moq = CreateMockRepository();

            //Arrange - create a controller
            CountryController target = new CountryController(moq);

            //Action
            var result = target.Get().ToArray();

            //Assert
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void Insert_Country()
        {
            //Arrange - create mock repository               
            var moq = CreateMockRepository();

            //Arrange - create a controller            
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/country");
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "country" } });

            CountryController target = new CountryController(moq);

            target.ControllerContext = new HttpControllerContext(config, routeData, request);
            target.Request = request;
            target.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;

            Country newCountry = new Country(){ ID = 10, Name = "TEST" };

            //Action
            var result = target.Post(newCountry);
            var result2 = target.Get().ToArray();

            //Assert
            Assert.AreEqual(6, result2.Length);

            //Assert
            Assert.AreEqual(HttpStatusCode.Created, result.StatusCode);
        }

        [TestMethod]
        public void Can_Edit_Country()
        {
            var moq = CreateMockRepository();

            //Arrange - create a controller            
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Put, "http://localhost/api/country");
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "country" } });
            CountryController target = new CountryController(moq);
            target.ControllerContext = new HttpControllerContext(config, routeData, request);
            target.Request = request;
            target.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;

            //Action
                      
            var result = target.GetById(2);
            result.Name = "cc";
            var result2 = target.Put(result);
            var result3 = target.Get().ToArray();


            //Assert
            Assert.AreEqual(HttpStatusCode.OK, result2.StatusCode);
            Assert.AreEqual("cc", result3[1].Name);
        }

        [TestMethod]
        public void Can_Remove_Country()
        {
            var moq = CreateMockRepository();

            //Arrange - create a controller            
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Delete, "http://localhost/api/country");
            var route = config.Routes.MapHttpRoute("DefaultApi", "api/{controller}");
            var routeData = new HttpRouteData(route, new HttpRouteValueDictionary { { "controller", "country" } });
            CountryController target = new CountryController(moq);
            target.ControllerContext = new HttpControllerContext(config, routeData, request);
            target.Request = request;
            target.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;

            //Action

            var result = target.GetById(1);
            var result2 = target.Delete(result.ID);
            var result3 = target.Get().ToArray();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, result2.StatusCode);
         //   Assert.AreEqual("Country2", result3[0].Name);
            Assert.AreEqual(4, result3.Length);
        }
    }
}
