using Mvvm.Bootstrap;
using Mvvm.Contracts;
using Xamarin.Forms;

namespace Mvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AppContainer.BuildContainer();

            InitializeNavigation();
        }

        private async void InitializeNavigation()
        {
            var navigationService = AppContainer.Resolve<INavigationService>();
            await navigationService.InitializeAsync();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
