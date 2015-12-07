using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using WebUI.Controllers.API;
using Domain.Entities.Dictionaries;
using UnitTests.Infrastructure;

namespace UnitTests
{
    [TestClass]
    public sealed class PersonTests : BaseEntityUnitTest<Person>
    {
        public PersonTests()
        {
            // creating  fake Repository
            var persons = new List<Person>
             {
                 new Person {ID =1, FirstName = "Steven", LastName = "McConnell" },
                 new Person {ID =2, FirstName = "Bill", LastName = "Gates" },
                 new Person {ID =3, FirstName = "Larry", LastName = "Page" },
                 new Person {ID =4, FirstName = "Linus", LastName = "Torvalds" },
                 new Person {ID =5, FirstName = "Jeffrey", LastName = "Richter" }
             };

            // create a mock storage and pass list of persons
            var mockStorage = new MockStorage<Person>(persons);

            // get Mock Repository
            var moq = mockStorage.SetupAndReturnMock();

            // create Controller with Mock
            var controller = new PersonController(moq);

            // Init params of Controller
            ArrangeController(controller);
        }

        [TestMethod]
         public void Person_Get_All()
         {
            GetAll();
         }

         [TestMethod]
         public void Person_Get_By_Id()
         {
            GetById();
         }

         [TestMethod]
         public void Person_Can_Insert()
         {
            Insert();                   
         }

         [TestMethod]
         public void Person_Can_Edit()
         {
            Edit();
         }

         [TestMethod]
         public void Person_Can_Remove()
         {
            Remove();
         }

         [TestMethod]
         public void Person_Get_Paging_1_2()
         {
            GetAll(1, 2);
         }

         [TestMethod]
         public void Person_Get_Paging_5_1()
         {
            GetAll(5, 1);
        }

         [TestMethod]
         public void Person_Get_Paging_3_2()
         {
            GetAll(3, 2);
        }
    }
}
