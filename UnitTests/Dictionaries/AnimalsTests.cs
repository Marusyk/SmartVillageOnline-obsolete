using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Domain.Abstract;
using Domain.Entities;
using System.Linq;
using WebUI.Controllers.API;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;

namespace UnitTests.Dictionaries
{
    [TestClass]
    public class AnimalsTests : GenericDictionaryTests<Animals>
    {
        GenericDictionaryTests<Animals> a;

        public AnimalsTests()
        {
            var animals = new List<Animals>
            {
                new Animals {ID =1, Name ="Animal1" },
                new Animals {ID =2, Name ="Animal2" },
                new Animals {ID =3, Name ="Animal3" },
                new Animals {ID =4, Name ="Animal4" },
                new Animals {ID =5, Name ="Animal5" }
            };

            var moq = base.CreateMockRepository(animals);
            var controller = new AnimalsController(moq);
            base.ArrangeController(controller);
        }


        [TestMethod]
        public void Get_All_Animals()
        {
            base.GetAll();
        }

        //[TestMethod]
        //public void Can_Insert_Animal()
        //{
        //    //Arrange
        //    var controller = ArrangeController();

        //    //Arrange - create a new country for insert
        //    Animals newAnimal = new Animals() { ID = 10, Name = "TEST" };

        //    //Action
        //    var resultInsert = controller.Post(newAnimal);
        //    var resultSelect = controller.Get().ToArray();

        //    //Assert
        //    Assert.AreEqual(6, resultSelect.Length);
        //    Assert.AreEqual(HttpStatusCode.Created, resultInsert.StatusCode);
        //}

        //[TestMethod]
        //public void Can_Edit_Animal()
        //{
        //    //Arrange
        //    var controller = ArrangeController();

        //    //Action                     
        //    var animal = controller.GetById(1);
        //    animal.Name = "TEST";
        //    var resultUpdate = controller.Put(animal);
        //    var resultSelect = controller.Get().ToArray();

        //    //Assert
        //    Assert.AreEqual(HttpStatusCode.OK, resultUpdate.StatusCode);
        //    Assert.AreEqual("TEST", resultSelect[0].Name);
        //}

        //[TestMethod]
        //public void Can_Remove_Animal()
        //{
        //    //Arrange
        //    var controller = ArrangeController();

        //    //Action
        //    var animal = controller.GetById(1);
        //    var resultDelete = controller.Delete(animal.ID);
        //    var resultSelect = controller.Get().ToArray();

        //    //Assert
        //    Assert.AreEqual(HttpStatusCode.OK, resultDelete.StatusCode);
        //    Assert.AreEqual(4, resultSelect.Length);
        //}
    }
}
