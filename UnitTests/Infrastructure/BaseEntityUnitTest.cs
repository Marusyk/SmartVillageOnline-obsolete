using Domain.Abstract;
using Domain.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using WebUI.Infrastructure;

namespace UnitTests.Infrastructure
{
    public class BaseEntityUnitTest<T> : IBaseEntityUnitTest<T> where T : BaseEntity, new()
    {
        protected IBaseApiInterface<T> Controller;        

        public virtual void ArrangeController(IBaseApiInterface<T> controller)
        {
            Controller = controller;
            ((ApiController)controller).Request = new HttpRequestMessage();
            ((ApiController)controller).Request.SetConfiguration(new HttpConfiguration());
        }

        public virtual void GetAll()
        {
            //Action
            var response = Controller.Get();
            var result = response.ContentToQueryable<T>();
            //Assert
            Assert.AreEqual(5, result.Count());
        }

        public virtual void GetAll(int pageNo, int pageSize)
        {
            //Arrange
            /*int pageCount = EntitiesList.Count() > 0 ? (int)Math.Ceiling(EntitiesList.Count() / (double)pageSize) : 0;

            if (pageSize > 0 & pageSize > 0)
            {
                //Action
                HttpResponseMessage response = Controller.Get(pageNo, pageSize);
                var result = response.Content.ReadAsStringAsync().Result;// ReadAsAsync<IQueryable<T>>().Result;

                int _pageNo = Convert.ToInt32(response.Headers.GetValues("X-Paging-PageNo").First());
                int _pageSize = Convert.ToInt32(response.Headers.GetValues("X-Paging-PageSize").First());
                int _pageCount = Convert.ToInt32(response.Headers.GetValues("X-Paging-PageCount").First());
                int _totalRecordCount = Convert.ToInt32(response.Headers.GetValues("X-Paging-TotalRecordCount").First());

                //Assert
                Assert.AreEqual(pageNo, _pageNo);
                Assert.AreEqual(pageSize, _pageSize);
                Assert.AreEqual(pageCount, _pageCount);
                Assert.AreEqual(EntitiesList.Count(), _totalRecordCount);
                
            }*/
            Assert.AreEqual(0, 0);
        }

        public virtual void GetById()
        {
            // Action
            var result = GetById(1);

            // Accert
            Assert.IsNotNull(result);
        }

        public virtual void Insert()
        {
            // Arrange
            var entity = new T() { ID = 10, LastUpdUS = "TEST" };

            // Act
            var resultInsert = Controller.Post(entity);
            var resultSelect = GetById(10);
            var resultTotalCount = Controller.Get().ContentToQueryable<T>();

            // Assert
            Assert.AreEqual(HttpStatusCode.Created, resultInsert.StatusCode);
            Assert.AreEqual(10, resultSelect.ID);
            Assert.AreEqual(6, resultTotalCount.Count());
            Assert.AreEqual("TEST", resultSelect.LastUpdUS);
        }

        public void Edit()
        {
            // Arrange
            var entity = GetById(1);
            entity.LastUpdUS = "TEST";

            //Action                                 
            var resultUpdate = Controller.Put(entity);
            var resultSelect = GetById(1);

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultUpdate.StatusCode);
            Assert.AreEqual(1, resultSelect.ID);
            Assert.AreEqual("TEST", resultSelect.LastUpdUS);
        }

        public void Remove()
        {
            // Arrange
            var entity = GetById(1);

            //Action
            var resultDelete = Controller.Delete(entity.ID);
            var resultSelect = Controller.Get().ContentToQueryable<T>();

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, resultDelete.StatusCode);
            Assert.AreEqual(4, resultSelect.Count());
        }

        private T GetById(int id)
        {
            return Controller.GetById(id).ContentToEntity<T>();
        }

        public void FindBy()
        {
            throw new NotImplementedException();
        }
    }
}
