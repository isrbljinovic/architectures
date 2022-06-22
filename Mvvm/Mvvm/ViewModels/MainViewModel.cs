using Mvvm.Contracts;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mvvm.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public ICommand DokumentiViewCommand => new Command(OpenDokumenti);
        public ICommand CreateDokumentViewCommand => new Command(CreateDokument);
        public ICommand PartneriViewCommand => new Command(OpenPartneri);
        public ICommand ArtikliViewCommand => new Command(OpenArtikli);

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

        private async void OpenPartneri()
        {
            await _navigationService.NavigateToAsync<PartneriViewModel>();
        }


        private async void OpenArtikli()
        {
            await _navigationService.NavigateToAsync<ArtikliViewModel>();
        }
    }
}

