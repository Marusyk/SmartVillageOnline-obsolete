using Domain.Abstract;
using System.Collections.Generic;
using WebUI.Infrastructure;

namespace UnitTests.Infrastructure
{
    internal interface IBaseEntityUnitTest<out T> where T : BaseEntity
    {
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
