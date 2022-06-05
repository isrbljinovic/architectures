using System.Collections.Generic;
using System.Collections.ObjectModel;
using Mvvm.Contracts;
using Mvvm.Models;
using Xamarin.Forms;

namespace Mvvm.ViewModels
{
    public class StavkeViewModel : BaseViewModel
	{
        private ObservableCollection<Stavka> _stavke;
        public ObservableCollection<Stavka> Stavke
        {
            get { return _stavke; }
            set { _stavke = value; OnPropertyChanged(); }
        }
        public StavkeViewModel(INavigationService navigationService) : base(navigationService)
		{

			MessagingCenter.Subscribe<DokumentiViewModel, List<Stavka>>(this, "StavkeView",
			   (dokumentiViewModel, stavke) => Sync(stavke));
		}

        private void Sync(List<Stavka> stavke)
        {
            Stavke = new ObservableCollection<Stavka>(stavke);
            MessagingCenter.Unsubscribe<DokumentiViewModel>(this, "StavkeView");
        }

    }
}

