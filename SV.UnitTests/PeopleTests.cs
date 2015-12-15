using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Entities;
using System.Collections.Generic;
using WebUI.Controllers.API;
using UnitTests.Infrastructure;

namespace UnitTests
{
    [TestClass]
    public sealed class PeopleTests : BaseEntityUnitTest<People>
    {
        public PeopleTests()
        {
            // creating  fake Repository
            var peopels = new List<People>
            {
                new People {ID =1, HouseID = 1, PersonID = 1, PeopleNumber = 1 },
                new People {ID =2, HouseID = 1, PersonID = 2, PeopleNumber = 2 },
                new People {ID =3, HouseID = 2, PersonID = 3, PeopleNumber = 1 },
                new People {ID =4, HouseID = 3, PersonID = 4, PeopleNumber = 1 },
                new People {ID =5, HouseID = 3, PersonID = 5, PeopleNumber = 2 }
            };

            // create a mock storage and pass list of peopels
            var mockStorage = new MockStorage<People>(peopels);

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create Controller with Mock
            var controller = new PeopleController(moq);

            // Init params of Controller
            ArrangeController(controller);
        }

        [TestMethod]
        public void People_Get_All()
        {
            GetAll();
        }

        [TestMethod]
        public void People_Get_By_Id()
        {
            GetById();
        }

        [TestMethod]
        public void People_Can_Insert()
        {
            Insert();
        }

        [TestMethod]
        public void People_Can_Edit()
        {
            Edit();
        }

        [TestMethod]
        public void People_Can_Remove()
        {
            Remove();
        }
    }
}
