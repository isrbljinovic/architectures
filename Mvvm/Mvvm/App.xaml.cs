using Mvvm.Bootstrap;
using Mvvm.Views;
using Xamarin.Forms;

namespace Mvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            AppContainer.BuildContainer();

            MainPage = new DokumentiView();
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
