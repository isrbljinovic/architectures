using System.Collections.ObjectModel;
using Mvvm.Contracts;
using Mvvm.Models;

namespace Mvvm.ViewModels
{
    public class PartneriViewModel : BaseViewModel
    {
        private readonly IPartneriService _partneriService;

        private ObservableCollection<Partner> _partneri;
        public ObservableCollection<Partner> Partneri { get { return _partneri; } set { _partneri = value; OnPropertyChanged(); } }

        public PartneriViewModel(
            INavigationService navigationService,
            IPartneriService partneriService) : base(navigationService)
        {
            _partneriService = partneriService;
            Init();
        }

        private async void Init()
        {
            Partneri = new ObservableCollection<Partner>(await _partneriService.GetAll());
        }
    }
}

