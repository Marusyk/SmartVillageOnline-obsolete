using Domain.Abstract;
using Domain.Entities.SystemTables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Moq;
using WebUI.Controllers.API;
using System.Web.Http;
using System.Net.Http;
using UnitTests.Infrastructure;

namespace UnitTests
{
    [TestClass]
    public class DictionariesTests
    {
        #region private

        private IRepository<SYS_Dictionary> CreateMockRepository()
        {
            // creating  fake Repository
            var dictionaries = new List<SYS_Dictionary>
            {
                new SYS_Dictionary {ID =1, Name ="Dictionary1", IsStatic = true },
                new SYS_Dictionary {ID =2, Name ="Dictionary2", IsStatic = false},
                new SYS_Dictionary {ID =3, Name ="Dictionary3", IsStatic = true }
            };

            // configure the Mock Object
            Mock<IRepository<SYS_Dictionary>> mock = new Mock<IRepository<SYS_Dictionary>>();

            mock.Setup(m => m.GetAll()).Returns(dictionaries.AsQueryable());           

            return mock.Object;
        }

        #endregion

        [TestMethod]
        public void Get_All_Dictionary()
        {
            //Arrange - create mock Repository               
            var moq = CreateMockRepository();

            //Arrange - create a controller
            var target = new DictionaryController(moq);
            target.Request = new HttpRequestMessage();
            target.Request.SetConfiguration(new HttpConfiguration());

            //Action
            HttpResponseMessage response = target.Get();
            var result = response.ContentToQueryable<SYS_Dictionary>();

            //Assert
            Assert.AreEqual(3, result.Count());
        }

    }
}
