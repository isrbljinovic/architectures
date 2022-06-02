using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
namespace Mvvm.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        //protected readonly INavigationService _navigationService;
        
        public ViewModelBase()
        {
        }

        private bool _isBusy;

        public event PropertyChangedEventHandler PropertyChanged;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task InitializeAsync(object data)
        {
            return Task.FromResult(false);
        }
    }
}

