using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Abstract;
using Domain.Entities;
using System.Linq;
using WebUI.Controllers.API;
using System.Net;
using System.Net.Http;

namespace UnitTests
{
    [TestClass]
    public class CountryTests
    {
        #region private

        private IRepository<Country> CreateMockRepository()
        {
            Mock<IRepository<Country>> mock = new Mock<IRepository<Country>>();
            mock.Setup(m => m.Table).Returns(new Country[]
            {
                new Country {ID =1, Name ="Country1" },
                new Country {ID =2, Name ="Country2" },
                new Country {ID =3, Name ="Country3" },
                new Country {ID =4, Name ="Country4" },
                new Country {ID =5, Name ="Country5" }
            }.AsQueryable());

            return mock.Object;
        }

        #endregion

        [TestMethod]
        public void Get_All_Country()
        {
            //Arrange - create mock repository               
            var moq = CreateMockRepository();

            //Arrange - create a controller
            CountryController target = new CountryController(moq);

            //Action
            var result = target.Get().ToArray();

            //Assert
            Assert.AreEqual(5, result.Length);
        }

        [TestMethod]
        public void Insert_Country()
        {
 
        }

        [TestMethod]
        public void Can_Edit_Country()
        {

        }

        [TestMethod]
        public void Can_Remove_Country()
        {

        }
    }
}
