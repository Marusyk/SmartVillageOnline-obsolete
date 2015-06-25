﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
                .Callback<Country>(c => countries.Where(d => d.ID == 1).FirstOrDefault());

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

            Country newCountry = new Country() { ID = 1, Name = "TEST" };

            //Action
            var result = target.Put(newCountry);
            var result2 = target.Get().ToArray();

            //Assert
           // Assert.AreEqual("TEST", result2[0].Name);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void Can_Remove_Country()
        {

        }
    }
}
