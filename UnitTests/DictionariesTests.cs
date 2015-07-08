using Domain.Abstract;
using Domain.Entities.SystemTables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WebApi.Controllers.API;

namespace UnitTests
{
    [TestClass]
    public class DictionariesTests
    {
        #region private

        private IRepository<SYS_Dictionary> CreateMockRepository()
        {
            // creating  fake repository
            var dictionaries = new List<SYS_Dictionary>
            {
                new SYS_Dictionary {ID =1, Name ="Dictionary1", IsStatic = true },
                new SYS_Dictionary {ID =2, Name ="Dictionary2", IsStatic = false},
                new SYS_Dictionary {ID =3, Name ="Dictionary3", IsStatic = true }
            };

            // configure the Mock Object
            Mock<IRepository<SYS_Dictionary>> mock = new Mock<IRepository<SYS_Dictionary>>();

            mock.Setup(m => m.Table).Returns(dictionaries.AsQueryable());           

            return mock.Object;
        }

        #endregion

        [TestMethod]
        public void Get_All_Dictionary()
        {
            //Arrange - create mock repository               
            var moq = CreateMockRepository();

            //Arrange - create a controller
            DictionaryController target = new DictionaryController(moq);

            //Action
            var result = target.Get().ToArray();

            //Assert
            Assert.AreEqual(3, result.Length);
            Assert.IsFalse(result[1].IsStatic);
        }

    }
}
