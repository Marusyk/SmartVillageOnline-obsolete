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
    public class PeopleTests
    {
        #region private

        private IRepository<People> CreateMockRepository()
        {
            // creating  fake Repository
            var persons = new List<People>
            {
                new People {ID =1, HouseID = 1, PersonID = 1, PeopleNumber = 1 },
                new People {ID =2, HouseID = 1, PersonID = 2, PeopleNumber = 2 },
                new People {ID =3, HouseID = 2, PersonID = 3, PeopleNumber = 1 },
                new People {ID =4, HouseID = 3, PersonID = 4, PeopleNumber = 1 },
                new People {ID =5, HouseID = 3, PersonID = 5, PeopleNumber = 2 }
            };

            // configure the Mock Object
            Mock<IRepository<People>> mock = new Mock<IRepository<People>>();

            mock.Setup(m => m.All).Returns(persons.AsQueryable());

            mock.Setup(m => m.Add(It.IsAny<People>()))
                .Callback<People>(c => persons.Add(c));

            mock.Setup(m => m.Edit(It.IsAny<People>()))
                .Callback<People>(c => persons[persons.IndexOf(c)] = c);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns<int>(c => persons.Find(f => f.ID == c));

            mock.Setup(m => m.Delete(It.IsAny<People>()))
                .Callback<People>(c => persons.Remove(c));

            return mock.Object;
        }

        private PeopleController ArrangeController()
        {
            // Get the mock Repository
            var moq = CreateMockRepository();
            var controller = new PeopleController(moq);
            controller.Request = new HttpRequestMessage();
            controller.Request.SetConfiguration(new HttpConfiguration());
            return controller;
        }

        #endregion

        [TestMethod]
        public void People_Get_All()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            HttpResponseMessage response = target.Get();
            var model = response.Content.ReadAsStringAsync().Result;// ReadAsAsync<IQueryable<People>>().Result;

            //Assert
            Assert.AreEqual(5, model.Count());
        }

        [TestMethod]
        public void People_Get_By_Id()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            HttpResponseMessage response = target.GetById(1);
            var model = response.Content.ReadAsStringAsync().Result;// ReadAsAsync<People>().Result;

            //Assert
            //Assert.AreEqual(1, model.ID);
        }

        [TestMethod]
        public void People_Can_Insert()
        {
            //Arrange
            var target = ArrangeController();

            //Arrange - create a new people for insert
            var newPeople = new People() { ID = 10, HouseID = 11, PersonID = 12};

            //Action
            var resultInsert = target.Post(newPeople);
            var resultSelect = target.GetById(10).Content.ReadAsStringAsync().Result;// ReadAsAsync<People>().Result;
            var resultTotalCount = target.Get().Content.ReadAsStringAsync().Result;// ReadAsAsync<IQueryable<People>>().Result;

            //Assert
        //    Assert.AreEqual(HttpStatusCode.Created, resultInsert.StatusCode);
        //    Assert.AreEqual(10, resultSelect.ID);
        //    Assert.AreEqual(6, resultTotalCount.Count());
        //    Assert.AreEqual(11, resultSelect.HouseID);
        //    Assert.AreEqual(12, resultSelect.PersonID);
        }

        [TestMethod]
        public void People_Can_Edit()
        {
            //Arrange
            var target = ArrangeController();

            //Action                     
            var people = target.GetById(1).Content.ReadAsStringAsync().Result;// ReadAsAsync<People>().Result;
            //people.HouseID = 99;
            //var resultUpdate = target.Put(people);
            //var resultSelect = target.GetById(1).Content.ReadAsStringAsync().Result;// ReadAsAsync<People>().Result;

            ////Assert
            //Assert.AreEqual(HttpStatusCode.OK, resultUpdate.StatusCode);
            //Assert.AreEqual(1, resultSelect.ID);
            //Assert.AreEqual(99, resultSelect.HouseID);
        }

        [TestMethod]
        public void People_Can_Remove()
        {
            //Arrange
            var target = ArrangeController();

            //Action
            //var people = target.GetById(1).Content.ReadAsAsync<People>().Result;
            //var resultDelete = target.Delete(people.ID);
            //var resultSelect = target.Get().Content.ReadAsAsync<IQueryable<People>>().Result;

            ////Assert
            //Assert.AreEqual(HttpStatusCode.OK, resultDelete.StatusCode);
            //Assert.AreEqual(4, resultSelect.Count());
        }


    }
}
