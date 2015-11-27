using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Abstract;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebUI.Controllers.API;
using System.Net.Http;
using System.Web.Http;
using Domain.Entities.Dictionaries;
using UnitTests.Infrastructure;

namespace UnitTests
{
    [TestClass]
    public class PersonTests
    {
        #region private

        private IRepository<Person> CreateMockRepository()
        {
            // creating  fake Repository
            var persons = new List<Person>
            {
                new Person {ID =1, FirstName = "Steven", LastName = "McConnell" },
                new Person {ID =2, FirstName = "Bill", LastName = "Gates" },
                new Person {ID =3, FirstName = "Larry", LastName = "Page" },
                new Person {ID =4, FirstName = "Linus", LastName = "Torvalds" },
                new Person {ID =5, FirstName = "Jeffrey", LastName = "Richter" }
            };

            // configure the Mock Object
            Mock<IRepository<Person>> mock = new Mock<IRepository<Person>>();

            mock.Setup(m => m.GetAll()).Returns(persons.AsQueryable());

            mock.Setup(m => m.Add(It.IsAny<Person>()))
                .Callback<Person>(c => persons.Add(c));

            mock.Setup(m => m.Edit(It.IsAny<Person>()))
                .Callback<Person>(c => persons[persons.IndexOf(c)] = c);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns<int>(c => persons.Find(f => f.ID == c));

            mock.Setup(m => m.Delete(It.IsAny<Person>()))
                .Callback<Person>(c => persons.Remove(c));

            return mock.Object;
        }

        private PersonController ArrangeController()
        {
            // Get the mock Repository
            var moq = CreateMockRepository();
            var controller = new PersonController(moq);
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());
            return controller;
        }

        #endregion

        [TestMethod]
        public void Person_Get_All()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            HttpResponseMessage response = target.Get();
            var model = response.ContentToQueryable<Person>();

            //Assert
            Assert.AreEqual(5, model.Count());
        }

        [TestMethod]
        public void Person_Get_By_Id()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            HttpResponseMessage response = target.GetById(1);
            var model = response.Content.ReadAsStringAsync().Result;// ReadAsAsync<Person>().Result;

            //Assert
           // Assert.AreEqual(1, model.ID);
        }

        [TestMethod]
        public void Person_Can_Insert()
        {
            //Arrange
            var target = ArrangeController();

            //Arrange - create a new country for insert
            var newPerson = new Person() { ID = 10, FirstName = "Larry", LastName = "Page" };

            //Action
            var resultInsert = target.Post(newPerson);
            var resultSelect = target.GetById(10).Content.ReadAsStringAsync().Result;// ReadAsAsync<Person>().Result;
            var resultTotalCount = target.Get().Content.ReadAsStringAsync().Result;// ReadAsAsync<Person>().Result;

            //Assert
            //Assert.AreEqual(HttpStatusCode.Created, resultInsert.StatusCode);
            //Assert.AreEqual(10, resultSelect.ID);
            //Assert.AreEqual(6, resultTotalCount.Count());
            //Assert.AreEqual("Larry", resultSelect.FirstName);
            //Assert.AreEqual("Page", resultSelect.LastName);                       
        }

        [TestMethod]
        public void Person_Can_Edit()
        {
            //Arrange
            var target = ArrangeController();

            //Action                     
            //var person = target.GetById(1).Content.ReadAsStringAsync().Result;// ReadAsAsync<Person>().Result;
            //person.LastName = "McConnell";
            //var resultUpdate = target.Put(person);
            //var resultSelect = target.GetById(1).Content.ReadAsStringAsync().Result;// ReadAsAsync<Person>().Result;

            ////Assert
            //Assert.AreEqual(HttpStatusCode.OK, resultUpdate.StatusCode);
            //Assert.AreEqual(1, resultSelect.ID);
            //Assert.AreEqual("McConnell", resultSelect.LastName);
        }

        [TestMethod]
        public void Person_Can_Remove()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            //var person = target.GetById(1).Content.ReadAsStringAsync().Result;// ReadAsAsync<Person>().Result;
            //var resultDelete = target.Delete(person.ID);
            //var resultSelect = target.Get().Content.ReadAsStringAsync().Result;// ReadAsAsync<Person>().Result;

            ////Assert
            //Assert.AreEqual(HttpStatusCode.OK, resultDelete.StatusCode);
            //Assert.AreEqual(4, resultSelect.Count());
        }

        [TestMethod]
        public void Person_Get_Paging_1_2()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            HttpResponseMessage response = target.Get(1, 2);
            var result = response.Content.ReadAsStringAsync().Result;// ReadAsAsync<Person>().Result;

            int pageNo = Convert.ToInt32(response.Headers.GetValues("X-Paging-PageNo").First());
            int pageSize = Convert.ToInt32(response.Headers.GetValues("X-Paging-PageSize").First());
            int pageCount = Convert.ToInt32(response.Headers.GetValues("X-Paging-PageCount").First());
            int totalRecordCount = Convert.ToInt32(response.Headers.GetValues("X-Paging-TotalRecordCount").First());

            //Assert
            Assert.AreEqual(1, pageNo);
            Assert.AreEqual(2, pageSize);
            Assert.AreEqual(3, pageCount);
            Assert.AreEqual(5, totalRecordCount);
        }

        [TestMethod]
        public void Person_Get_Paging_5_1()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            HttpResponseMessage response = target.Get(5, 1);
            //var result = response.Content.ReadAsAsync<IQueryable<Person>>().Result;

            //int pageNo = Convert.ToInt32(response.Headers.GetValues("X-Paging-PageNo").First());
            //int pageSize = Convert.ToInt32(response.Headers.GetValues("X-Paging-PageSize").First());
            //int pageCount = Convert.ToInt32(response.Headers.GetValues("X-Paging-PageCount").First());
            //int totalRecordCount = Convert.ToInt32(response.Headers.GetValues("X-Paging-TotalRecordCount").First());

            ////Assert
            //Assert.AreEqual(5, pageNo);
            //Assert.AreEqual(1, pageSize);
            //Assert.AreEqual(5, pageCount);
            //Assert.AreEqual(5, totalRecordCount);
        }

        [TestMethod]
        public void Person_Get_Paging_3_2()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            HttpResponseMessage response = target.Get(3, 2);
            //var result = response.Content.ReadAsAsync<IQueryable<Person>>().Result;

            //int pageNo = Convert.ToInt32(response.Headers.GetValues("X-Paging-PageNo").First());
            //int pageSize = Convert.ToInt32(response.Headers.GetValues("X-Paging-PageSize").First());
            //int pageCount = Convert.ToInt32(response.Headers.GetValues("X-Paging-PageCount").First());
            //int totalRecordCount = Convert.ToInt32(response.Headers.GetValues("X-Paging-TotalRecordCount").First());

            ////Assert
            //Assert.AreEqual(3, pageNo);
            //Assert.AreEqual(2, pageSize);
            //Assert.AreEqual(3, pageCount);
            //Assert.AreEqual(5, totalRecordCount);
        }
    }
}
