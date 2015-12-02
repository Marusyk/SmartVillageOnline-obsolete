using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Abstract;
using Moq;
using System.Collections.Generic;
using System.Linq;
using WebUI.Controllers.API;
using System.Net.Http;
using System.Web.Http;
using Domain.Entities.Dictionaries;
using UnitTests.Infrastructure;

namespace UnitTests
{
    [TestClass]
    public class PersonTests : BaseEntityUnitTest<Person>
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

            base.EntitiesList = persons;

            // get Mock Repository from base class
            var moq = base.CreateMockRepository();

            // create Controller with Mock
            var controller = new PersonController(moq);

            // Init params of Controller
            base.ArrangeController(controller);
        }

        [TestMethod]
         public void Person_Get_All()
         {
            base.GetAll();
         }

         [TestMethod]
         public void Person_Get_By_Id()
         {
            base.GetById();
         }

         [TestMethod]
         public void Person_Can_Insert()
         {
            base.Insert();                   
         }

         [TestMethod]
         public void Person_Can_Edit()
         {
            base.Edit();
         }

         [TestMethod]
         public void Person_Can_Remove()
         {
            base.Remove();
         }

         [TestMethod]
         public void Person_Get_Paging_1_2()
         {
            base.GetAll(1, 2);
         }

         [TestMethod]
         public void Person_Get_Paging_5_1()
         {
            base.GetAll(5, 1);
        }

         [TestMethod]
         public void Person_Get_Paging_3_2()
         {
            base.GetAll(3, 2);
        }
    }
}
