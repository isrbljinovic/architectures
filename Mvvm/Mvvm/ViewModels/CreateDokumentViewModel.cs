using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Mvvm.Contracts;
using Mvvm.Models;
using Xamarin.Forms;

namespace Mvvm.ViewModels
{
    public class CreateDokumentViewModel : BaseViewModel
    {
        private ObservableCollection<Stavka> _stavke;
        private Dokument _dokument;
        private int _sifraArtikla;
        private double _kolicinaArtikla;
        private readonly IDokumentiService _dokumentiService;

        public ObservableCollection<Stavka> Stavke { get { return _stavke; } set { _stavke = value; OnPropertyChanged(); } }

        public Dokument Dokument { get { return _dokument; } set { _dokument = value; OnPropertyChanged(); } }

        public int SifraArtikla { get { return _sifraArtikla; } set { _sifraArtikla = value; OnPropertyChanged(); } }
        public double KolicinaArtikla { get { return _kolicinaArtikla; } set { _kolicinaArtikla = value; OnPropertyChanged(); } }

        public CreateDokumentViewModel(
            INavigationService navigationService,
            IDokumentiService dokumentiService)
            : base(navigationService)
        {
            Dokument = new Dokument();
            Stavke = new ObservableCollection<Stavka>();
            _dokumentiService = dokumentiService;
        }

        public ICommand DodajArtiklCommand => new Command(DodajArtikl);

        private async void DodajArtikl()
        {
            var naziv = await _dokumentiService.GetNazivArtikla(SifraArtikla);

            Stavke.Add(new Stavka
            {
                Kolicina = KolicinaArtikla,
                SifraArtikla = SifraArtikla,
                NazivArtikla = naziv
            });
        }

        public ICommand SpremiDokumentCommand => new Command(SpremiDokument);

        private async void SpremiDokument()
        {
            Dokument.Stavkas = new List<Stavka>(Stavke);

            await _dokumentiService.Create(Dokument);

            await _navigationService.NavigateBackAsync();
        }
    }
}

