using System;
using Autofac;
using Mvvm.Contracts;
using Mvvm.Services;
using Mvvm.ViewModels;

namespace Mvvm.Bootstrap
{
	public class AppContainer
	{
        private static IContainer _container;

        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DokumentiViewModel>();
            builder.RegisterType<StavkeViewModel>();
            builder.RegisterType<CreateDokumentViewModel>();
            builder.RegisterType<MainViewModel>();


            builder.RegisterType<HttpHandler>().As<IHttpHandler>();
            builder.RegisterType<DokumentiService>().As<IDokumentiService>();
            builder.RegisterType<PartneriService>().As<IPartneriService>();
            builder.RegisterType<ArtikliService>().As<IArtikliService>();
            builder.RegisterType<NavigationService>().As<INavigationService>();

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

