using Mvvm.Contracts;
using Mvvm.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mvvm.ViewModels
{
    public class DokumentiViewModel : BaseViewModel
    {
        private readonly IDokumentiService _dokumentiService;

        private ObservableCollection<Dokument> _dokumenti;
        public ObservableCollection<Dokument> Dokumenti { get { return _dokumenti; } set { _dokumenti = value; OnPropertyChanged(); } }

        private Dokument _selectedDokument;
        public Dokument SelectedDokument
        {
            get { return _selectedDokument; }
            set { _selectedDokument = value; OnPropertyChanged(); }
        }

        public DokumentiViewModel(
            INavigationService navigationService,
            IDokumentiService dokumentiService) : base(navigationService)
        {
            _dokumentiService = dokumentiService;
            Init();
        }

        public ICommand DokumentiViewCommand => new Command(OpenStavke);
        public ICommand ItemSelectedCommand => new Command(OpenStavke);

        private async void OpenStavke()
        {
            await _navigationService.NavigateToAsync<StavkeViewModel>();
            MessagingCenter.Send(this, "StavkeView", SelectedDokument);
        }

        private async void Init()
        {
            Dokumenti = new ObservableCollection<Dokument>(await _dokumentiService.GettAll());
        }
    }
}

