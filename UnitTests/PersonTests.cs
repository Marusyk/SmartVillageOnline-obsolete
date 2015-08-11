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
    public class PersonTests
    {
        #region private

        private IRepository<Person> CreateMockRepository()
        {
            // creating  fake repository
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

            mock.Setup(m => m.Table).Returns(persons.AsQueryable());

            mock.Setup(m => m.Insert(It.IsAny<Person>()))
                .Callback<Person>(c => persons.Add(c));

            mock.Setup(m => m.Update(It.IsAny<Person>()))
                .Callback<Person>(c => persons[persons.IndexOf(c)] = c);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns<int>(c => persons.Find(f => f.ID == c));

            mock.Setup(m => m.Delete(It.IsAny<Person>()))
                .Callback<Person>(c => persons.Remove(c));

            return mock.Object;
        }

        private PersonController ArrangeController()
        {
            // Get the mock repository
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
            var result = target.Get().ToArray();

            //Assert
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void Person_Can_Insert()
        {
            //Arrange
            var target = ArrangeController();

            //Arrange - create a new country for insert
            var newPerson = new Person() { ID = 10, FirstName = "Sergey", LastName = "Brin" };

            //Action
            var resultInsert = target.Post(newPerson);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(6, resultSelect.Length);
            Assert.AreEqual(HttpStatusCode.Created, resultInsert.StatusCode);
        }

        [TestMethod]
        public void Person_Can_Edit()
        {
            //Arrange
            var target = ArrangeController();

            //Action                     
            var person = target.GetById(1);
            person.LastName = "McConnell";
            var resultUpdate = target.Put(person);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultUpdate.StatusCode);
            Assert.AreEqual("McConnell", resultSelect[0].LastName);
        }

        [TestMethod]
        public void PErson_Can_Remove()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            var person = target.GetById(1);
            var resultDelete = target.Delete(person.ID);
            var resultSelect = target.Get().ToArray();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultDelete.StatusCode);
            Assert.AreEqual(4, resultSelect.Length);
        }
    }
}
