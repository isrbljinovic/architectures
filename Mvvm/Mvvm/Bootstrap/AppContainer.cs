using System;
using Autofac;

namespace Mvvm.Bootstrap
{
	public class AppContainer
	{
        private static IContainer _container;

        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();

            //builder.RegisterType<LoginViewModel>();

            //builder.RegisterType<NavigationService>().As<INavigationService>();

            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}

