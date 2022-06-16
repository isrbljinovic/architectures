using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Mvvm.Contracts;
using Mvvm.Models;
using Xamarin.Forms;

namespace Mvvm.ViewModels
{
    public class StavkeViewModel : BaseViewModel
	{
        private IDokumentiService _dokumentiService;

        private ObservableCollection<Stavka> _stavke;
        public ObservableCollection<Stavka> Stavke
        {
            get { return _stavke; }
            set { _stavke = value; OnPropertyChanged(); }
        }

        private Dokument _dokument;
        public Dokument Dokument { get { return _dokument; } set { _dokument = value; OnPropertyChanged(); } }

        public StavkeViewModel(
            INavigationService navigationService,
            IDokumentiService dokumentiService) : base(navigationService)
		{
            _dokumentiService = dokumentiService;
			MessagingCenter.Subscribe<DokumentiViewModel, Dokument>(this, "StavkeView",
			   (dokumentiViewModel, dokument) => Sync(dokument));
		}

        public ICommand ObrisiDokumentCommand => new Command(ObrisiDokument);

        private async void ObrisiDokument()
        {
            await _dokumentiService.Delete(Dokument.Id);
            await _navigationService.NavigateBackAsync();
        }

        public ICommand SpremiDokumentCommand => new Command(SpremiDokument);
        public ICommand DeleteStavkaCommand => new Command<object>(DeleteStavka);

        private void DeleteStavka(object stavka)
        {
        }

        private async void SpremiDokument()
        {
            await _dokumentiService.Update(Dokument);
        }

        private void Sync(Dokument dokument)
        {
            Dokument = dokument;
            Stavke = new ObservableCollection<Stavka>(dokument.Stavkas);
            MessagingCenter.Unsubscribe<DokumentiViewModel>(this, "StavkeView");
        }

    }
}

