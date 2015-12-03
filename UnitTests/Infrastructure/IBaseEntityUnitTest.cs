using Domain.Abstract;
using WebUI.Infrastructure;

namespace UnitTests.Infrastructure
{
    interface IBaseEntityUnitTest<T> where T : BaseEntity
    {
        IRepository<T> CreateMockRepository();
        void ArrangeController(IBaseApiInterface<T> controller);

        void GetAll();
        void GetById();
        void GetAll(int pageNo, int pageSize);
        void Insert();
        void Edit();
        void Remove();
        void FindBy();
    }
}
