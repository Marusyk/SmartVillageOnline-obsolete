using Domain.Abstract;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests.Infrastructure
{
    class MockStorage<T> where T : BaseEntity, new()
    {
        private Mock<IRepository<T>> _mock = new Mock<IRepository<T>>();
        private List<T> _entitiesList;

        public MockStorage(List<T> entitiesList)
        {
            _entitiesList = entitiesList;
        }

        public MockStorage()
        {
            _entitiesList = CreateDefaultList();
        }

        private static List<T> CreateDefaultList()
        {
            return new List<T>
            {
                new T {ID = 1, LastUpdUS = "Entity1" },
                new T {ID = 2, LastUpdUS = "Entity2" },
                new T {ID = 3, LastUpdUS = "Entity3" },
                new T {ID = 4, LastUpdUS = "Entity4" },
                new T {ID = 5, LastUpdUS = "Entity5" }
            };
        }

        public void SetupMock()
        {
            // GetAll()
            _mock.Setup(m => m.GetAll()).Returns(_entitiesList.AsQueryable());

            //GetById(int id)
            _mock.Setup(m => m.GetById(It.IsAny<int>()))
               .Returns<int>(c => _entitiesList.Find(f => f.ID == c));           

            // Add()
            _mock.Setup(m => m.Add(It.IsAny<T>()))
                .Callback<T>(c => _entitiesList.Add(c));

            // Edit
            _mock.Setup(m => m.Edit(It.IsAny<T>()))
                .Callback<T>(c => _entitiesList[_entitiesList.IndexOf(c)] = c);

            // Delete
            _mock.Setup(m => m.Delete(It.IsAny<T>()))
                .Callback<T>(c => _entitiesList.Remove(c));

            // Paginate
            // TODO: 
            // FindBy()
            //mock.Setup(m => m.FindBy(f => f.LastUpdUS == It.IsAny<string>()))
            //    .Returns(EntitiesList.AsQueryable());
        }

        public IRepository<T> ReturnMock()
        {
            return _mock.Object;
        }

        public IRepository<T> SetupAndReturnMock()
        {
            SetupMock();
            return _mock.Object;
        }
    }
}
