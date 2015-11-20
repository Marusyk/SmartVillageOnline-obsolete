using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Domain.Concrete;
using Domain.Abstract;

namespace WebUI.Infrastructure
{
    // реалізація користувацької фабрики контроллерів
    // успадковуючись від фабрики яка використовується по замовчуванню
    public class NinjectControlFactory : DefaultControllerFactory
    {
        private readonly IKernel _ninjectKernel;
        public NinjectControlFactory()
        {
            //створення контейнера
            _ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            //отримання об'єкту контролера з контейнеру використовуючи його тип
            return controllerType == null
                ? null
                : (IController)_ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            //конфігурування контейнеру
            //_ninjectKernel.Bind<IHouseRepository>().To<EFHouseRepository>();
            _ninjectKernel.Bind(typeof(IRepository<>)).To(typeof(EFRepository<>));
        }
    }
}