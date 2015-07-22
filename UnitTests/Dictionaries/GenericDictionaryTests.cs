using Domain.Abstract;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebUI.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Dictionaries
{
    public class GenericDictionaryTests<T> where T : BaseEntity
    {
        IBaseApiInterface<T> controller;

        public GenericDictionaryTests()
        { }

        public IRepository<T> CreateMockRepository(List<T> entityList)
        {            
            // configure the Mock Object
            Mock<IRepository<T>> mock = new Mock<IRepository<T>>();

            mock.Setup(m => m.Table).Returns(entityList.AsQueryable());

            mock.Setup(m => m.Insert(It.IsAny<T>()))
                .Callback<T>(c => entityList.Add(c));

            mock.Setup(m => m.Update(It.IsAny<T>()))
                .Callback<T>(c => entityList[entityList.IndexOf(c)] = c);

            mock.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns<int>(c => entityList.Find(f => f.ID == c));

            mock.Setup(m => m.Delete(It.IsAny<T>()))
                .Callback<T>(c => entityList.Remove(c));

            return mock.Object;
        }

        public void ArrangeController(IBaseApiInterface<T> contr)
        {
            controller = contr;
            (controller as ApiController).Request = new HttpRequestMessage();
            (controller as ApiController).Request.SetConfiguration(new HttpConfiguration());
        }

        public void GetAll()
        {
            //Arrange
            //var controller = ArrangeController();

            //Action
            var result = controller.Get().ToArray();

            //Assert
            Assert.AreEqual(5, result.Length);
        }

        public void Insert()
        {

        }

        public void Edit()
        {

        }

        public void Remove()
        {

        }
    }
}
