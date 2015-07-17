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
            // creating  fake repository
            var countries = new List<Country>
            {
                new Country {ID =1, Name ="Country1" },
                new Country {ID =2, Name ="Country2" },
                new Country {ID =3, Name ="Country3" },
                new Country {ID =4, Name ="Country4" },
                new Country {ID =5, Name ="Country5" }
            };
            
            // configure the Mock Object
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

        private CountryController ArrangeController()
        {
            // Get the mock repository
            var moq = CreateMockRepository();
            var controller = new CountryController(moq);
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());
            return controller;
        }

        #endregion

        [TestMethod]
        public void Get_All_Country()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            var result = target.Get().ToArray();

            //Assert
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void Can_Insert_Country()
        {
            //Arrange
            var target = ArrangeController();

            //Arrange - create a new country for insert
            Country newCountry = new Country(){ ID = 10, Name = "TEST" };

            //Action
            var resultInsert = target.Post(newCountry);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(6, resultSelect.Length);
            Assert.AreEqual(HttpStatusCode.Created, resultInsert.StatusCode);
        }

        [TestMethod]
        public void Can_Edit_Country()
        {
            //Arrange
            var target = ArrangeController();

            //Action                     
            var country = target.GetById(1);
            country.Name = "TEST";
            var resultUpdate = target.Put(country);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultUpdate.StatusCode);
            Assert.AreEqual("TEST", resultSelect[0].Name);
        }

        [TestMethod]
        public void Can_Remove_Country()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            var country = target.GetById(1);
            var resultDelete = target.Delete(country.ID);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultDelete.StatusCode);
            Assert.AreEqual(4, resultSelect.Length);
        }
    }
}
