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
            var result = controller.Get().ToArray();

            //Assert
            Assert.AreEqual(5, result.Length);
        }

        protected virtual void GetById()
        {
            // Action
            var result = controller.GetById(1);

            // Accert
            Assert.IsNotNull(result);
        }

        protected virtual void Insert()
        {
            // Arrange
            var entity = new T() { ID = 10, Name = "TEST" };

            // Act
            var resultInsert = controller.Post(entity);
            var resultSelect = controller.Get().ToArray();

            // Assert
            Assert.AreEqual(6, resultSelect.Length);
            Assert.AreEqual(HttpStatusCode.Created, resultInsert.StatusCode);
        }

        protected void Edit()
        {
            // Arrange
            var entity = controller.GetById(1);
            entity.Name = "TEST";

            //Action                                 
            var resultUpdate = controller.Put(entity);
            var resultSelect = controller.Get().ToArray();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultUpdate.StatusCode);
            Assert.AreEqual("TEST", (resultSelect[0] as BaseDictionary).Name);
        }

        protected void Remove()
        {
            // Arrange
            var entity = controller.GetById(1);

            //Action
            var resultDelete = controller.Delete(entity.ID);
            var resultSelect = controller.Get().ToArray();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultDelete.StatusCode);
            Assert.AreEqual(4, resultSelect.Length);
        }
    }
}
