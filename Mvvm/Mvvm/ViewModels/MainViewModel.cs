using Mvvm.Contracts;
using System;
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

        private void OpenPartneri()
        {
            throw new NotImplementedException();
        }


        private void OpenArtikli()
        {
            throw new NotImplementedException();
        }

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

