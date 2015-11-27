using Domain.Abstract;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebUI.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

            // GetAll()
            mock.Setup(m => m.GetAll()).Returns(entitiesList.AsQueryable());

            //GetById(int id)
            mock.Setup(m => m.GetById(It.IsAny<int>()))
               .Returns<int>(c => entitiesList.Find(f => f.ID == c));

            // FindBy()
            mock.Setup(m => m.FindBy(f => f.Name == It.IsAny<string>()))
                .Returns(entitiesList.AsQueryable());

            // Add()
            mock.Setup(m => m.Add(It.IsAny<T>()))
                .Callback<T>(c => entitiesList.Add(c));

            // Edit
            mock.Setup(m => m.Edit(It.IsAny<T>()))
                .Callback<T>(c => entitiesList[entitiesList.IndexOf(c)] = c);

           // Delete
            mock.Setup(m => m.Delete(It.IsAny<T>()))
                .Callback<T>(c => entitiesList.Remove(c));            

            // Paginate
            // TODO: 

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
            var response = controller.Get();
            var result = response.ContentToQueryable<T>();
            //Assert
            Assert.AreEqual(5, result.Count());
        }

        protected virtual void GetAll(int pageNo = 1, int pageSize = 2)
        {
            //Arrange
            int pageCount = entitiesList.Count() > 0 ? (int)Math.Ceiling(entitiesList.Count() / (double)pageSize) : 0;

            if (pageSize > 0 & pageSize > 0)
            {
                //Action
                HttpResponseMessage response = controller.Get(pageNo, pageSize);
                var result = response.Content.ReadAsStringAsync().Result;// ReadAsAsync<IQueryable<T>>().Result;
                
                int _pageNo = Convert.ToInt32(response.Headers.GetValues("X-Paging-PageNo").First());
                int _pageSize = Convert.ToInt32(response.Headers.GetValues("X-Paging-PageSize").First());
                int _pageCount = Convert.ToInt32(response.Headers.GetValues("X-Paging-PageCount").First());
                int _totalRecordCount = Convert.ToInt32(response.Headers.GetValues("X-Paging-TotalRecordCount").First());

                //Assert
                Assert.AreEqual(pageNo, _pageNo);
                Assert.AreEqual(pageSize, _pageSize);
                Assert.AreEqual(pageCount, _pageCount);
                Assert.AreEqual(entitiesList.Count(), _totalRecordCount);
            }
        }

        protected virtual void GetById()
        {
            // Action
            var result = GetByID(1); 

            // Accert
            Assert.IsNotNull(result);
        }

        protected virtual void Insert()
        {
            // Arrange
            var entity = new T() { ID = 10, Name = "TEST" };

            // Act
            var resultInsert = controller.Post(entity);
            var resultSelect = GetByID(10);
            var resultTotalCount = controller.Get().ContentToQueryable<T>();

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, resultInsert.StatusCode);
            Assert.AreEqual(10, resultSelect.ID);
            Assert.AreEqual(6, resultTotalCount.Count());
            Assert.AreEqual("TEST", resultSelect.Name);
        }

        protected void Edit()
        {
            // Arrange
            var entity = GetByID(1);
            entity.Name = "TEST";

            //Action                                 
            var resultUpdate = controller.Put(entity);
            var resultSelect = GetByID(1);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultUpdate.StatusCode);
            Assert.AreEqual(1, resultSelect.ID);
            Assert.AreEqual("TEST", resultSelect.Name);
        }

        protected void Remove()
        {
            // Arrange
            var entity = GetByID(1);

            //Action
            var resultDelete = controller.Delete(entity.ID);
            var resultSelect = controller.Get().ContentToQueryable<T>();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultDelete.StatusCode);
            Assert.AreEqual(4, resultSelect.Count());
        }

        private T GetByID(int id)
        {
            return controller.GetById(id).ContentToEntity<T>();
        }
    }
}
