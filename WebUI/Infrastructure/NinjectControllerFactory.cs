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
        private IKernel ninjectKernel;
        public NinjectControlFactory()
        {
            //створення контейнера
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            //отримання об'єкту контролера з контейнеру використовуючи його тип
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            //конфігурування контейнеру
            //ninjectKernel.Bind<IHouseRepository>().To<EFHouseRepository>();
            ninjectKernel.Bind(typeof(IRepository<>)).To(typeof(EFRepository<>));
        }
    }
}