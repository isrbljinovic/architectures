using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Mvvm.Contracts;
using Mvvm.Models;

namespace Mvvm.ViewModels
{
    public class DokumentiViewModel : ViewModelBase
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

        public DokumentiViewModel(IDokumentiService dokumentiService)
		{
            _dokumentiService = dokumentiService;
            Init();
        }

        private async void Init()
        {
            Dokumenti = new ObservableCollection<Dokument>(await _dokumentiService.GettAll());
        }
    }
}

