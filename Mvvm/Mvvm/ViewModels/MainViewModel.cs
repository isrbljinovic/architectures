using System.Windows.Input;
using Mvvm.Contracts;
using Xamarin.Forms;

namespace Mvvm.ViewModels
{
    public class MainViewModel : BaseViewModel
	{
		public ICommand DokumentiViewCommand => new Command(OpenDokumenti);
		public ICommand CreateDokumentViewCommand => new Command(CreateDokument);

		public MainViewModel(INavigationService navigationService) : base(navigationService)
		{
		}

		private async void OpenDokumenti()
        {
			await _navigationService.NavigateToAsync<DokumentiViewModel>();
        }

		private async void CreateDokument()
        {
			await _navigationService.NavigateToAsync<CreateDokumentViewModel>();
        }
	}
}

