
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Mvvm.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirmaNavigationPage : NavigationPage
    {
        public FirmaNavigationPage()
        {
            InitializeComponent();
        }

        public FirmaNavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}

