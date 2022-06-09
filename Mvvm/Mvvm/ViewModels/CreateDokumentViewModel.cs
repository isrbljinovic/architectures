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
        private ObservableCollection<Partner> _partneri;
        private ObservableCollection<Artikl> _artikli;
        private Dokument _dokument;
        private Partner _partner;
        private Artikl _artikl;
        private int _sifraArtikla;
        private double _kolicinaArtikla;
        private readonly IDokumentiService _dokumentiService;
        private readonly IPartneriService _partneriService;
        private readonly IArtikliService _artikliService;

        public ObservableCollection<Stavka> Stavke { get { return _stavke; } set { _stavke = value; OnPropertyChanged(); } }
        public ObservableCollection<Partner> Partneri { get { return _partneri; } set { _partneri = value; OnPropertyChanged(); } }
        public ObservableCollection<Artikl> Artikli { get { return _artikli; } set { _artikli = value; OnPropertyChanged(); } }

        public Dokument Dokument { get { return _dokument; } set { _dokument = value; OnPropertyChanged(); } }
        public Partner SelectedPartner { get { return _partner; } set { _partner = value; OnPropertyChanged(); } }
        public Artikl SelectedArtikl { get { return _artikl; } set { _artikl = value; OnPropertyChanged(); } }

        public int SifraArtikla { get { return _sifraArtikla; } set { _sifraArtikla = value; OnPropertyChanged(); } }
        public double KolicinaArtikla { get { return _kolicinaArtikla; } set { _kolicinaArtikla = value; OnPropertyChanged(); } }

        public CreateDokumentViewModel(
            INavigationService navigationService,
            IDokumentiService dokumentiService,
            IPartneriService partneriService,
            IArtikliService artikliService)
            : base(navigationService)
        {
            Dokument = new Dokument();
            Stavke = new ObservableCollection<Stavka>();
            _dokumentiService = dokumentiService;
            _partneriService = partneriService;
            _artikliService = artikliService;
            Init();
        }

        private async void Init()
        {
            Partneri = new ObservableCollection<Partner>(await _partneriService.GetAll());
            Artikli = new ObservableCollection<Artikl>(await _artikliService.GetAll());
        }

        public ICommand DodajArtiklCommand => new Command(DodajArtikl);

        private async void DodajArtikl()
        {
            var naziv = await _dokumentiService.GetNazivArtikla(SelectedArtikl.Sifra);

            Stavke.Add(new Stavka
            {
                Kolicina = KolicinaArtikla,
                SifraArtikla = SelectedArtikl.Sifra,
                NazivArtikla = naziv
            });
        }

        public ICommand SpremiDokumentCommand => new Command(SpremiDokument);

        private async void SpremiDokument()
        {
            Dokument.Stavkas = new List<Stavka>(Stavke);
            Dokument.PartnerId = SelectedPartner.Id;

            await _dokumentiService.Create(Dokument);

            await _navigationService.NavigateBackAsync();
        }
    }
}

