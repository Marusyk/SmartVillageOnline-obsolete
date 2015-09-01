using Domain.Abstract;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebUI.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Dictionaries
{
    public class BaseDictionaryTests<T> where T : BaseDictionary, new()
    {
        protected IBaseApiInterface<T> controller;
        protected List<T> entitiesList = null;

        public BaseDictionaryTests()
        {
            entitiesList = new List<T>
            {
                new T {ID = 1, Name ="Entity1" },
                new T {ID = 2, Name ="Entity2" },
                new T {ID = 3, Name ="Entity3" },
                new T {ID = 4, Name ="Entity4" },
                new T {ID = 5, Name ="Entity5" }
            };
        }

        public BaseDictionaryTests(List<T> entitiesList)
        {
            this.entitiesList = entitiesList;
        }

        protected virtual IRepository<T> CreateMockRepository()
        {            
            // configure the standart Mock Object for CRUD operations
            Mock<IRepository<T>> mock = new Mock<IRepository<T>>();

            mock.Setup(m => m.Table).Returns(entitiesList.AsQueryable());

            mock.Setup(m => m.Insert(It.IsAny<T>()))
                .Callback<T>(c => entitiesList.Add(c));

            mock.Setup(m => m.Update(It.IsAny<T>()))
                .Callback<T>(c => entitiesList[entitiesList.IndexOf(c)] = c);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns<int>(c => entitiesList.Find(f => f.ID == c));

            mock.Setup(m => m.Delete(It.IsAny<T>()))
                .Callback<T>(c => entitiesList.Remove(c));            

            return mock.Object;
        }

        protected virtual void ArrangeController(IBaseApiInterface<T> controller)
        {
            this.controller = controller;
            (controller as ApiController).Request = new HttpRequestMessage();
            (controller as ApiController).Request.SetConfiguration(new HttpConfiguration());
        }

        protected virtual void GetAll()
        {
            //Action
            HttpResponseMessage response = controller.Get();
            var result = response.Content.ReadAsAsync<IQueryable<T>>().Result;

            //Assert
            Assert.AreEqual(5, result.Count());
        }

        protected virtual void GetById()
        {
            // Action
            HttpResponseMessage response = controller.GetById(1);
            var result = response.Content.ReadAsAsync<T>().Result;

            // Accert
            Assert.IsNotNull(result);
        }

        protected virtual void Insert()
        {
            // Arrange
            var entity = new T() { ID = 10, Name = "TEST" };

            // Act
            var resultInsert = controller.Post(entity);
            var resultSelect = controller.GetById(10).Content.ReadAsAsync<T>().Result;
            var resultTotalCount = controller.Get().Content.ReadAsAsync<IQueryable<T>>().Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, resultInsert.StatusCode);
            Assert.AreEqual(10, resultSelect.ID);
            Assert.AreEqual(6, resultTotalCount.Count());
            Assert.AreEqual("TEST", resultSelect.Name);
        }

        protected void Edit()
        {
            // Arrange
            var entity = controller.GetById(1).Content.ReadAsAsync<T>().Result;
            entity.Name = "TEST";

            //Action                                 
            var resultUpdate = controller.Put(entity);
            var resultSelect = controller.GetById(1).Content.ReadAsAsync<T>().Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultUpdate.StatusCode);
            Assert.AreEqual(1, resultSelect.ID);
            Assert.AreEqual("TEST", resultSelect.Name);
        }

        protected void Remove()
        {
            // Arrange
            var entity = controller.GetById(1).Content.ReadAsAsync<T>().Result;

            //Action
            var resultDelete = controller.Delete(entity.ID);
            var resultSelect = controller.Get().Content.ReadAsAsync<IQueryable<T>>().Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultDelete.StatusCode);
            Assert.AreEqual(4, resultSelect.Count());
        }
    }
}
