using System.Collections.ObjectModel;
using Mvvm.Contracts;
using Mvvm.Models;

namespace Mvvm.ViewModels
{
    public class ArtikliViewModel : BaseViewModel
    {
        private readonly IArtikliService _artikliService;

        private ObservableCollection<Artikl> _artikli;
        public ObservableCollection<Artikl> Artikli { get { return _artikli; } set { _artikli = value; OnPropertyChanged(); } }

        public ArtikliViewModel(
            INavigationService navigationService,
            IArtikliService artikliService) : base(navigationService)
        {
            _artikliService = artikliService;
            Init();
        }

        private async void Init()
        {
            Artikli = new ObservableCollection<Artikl>(await _artikliService.GetAll());
        }
    }
}

