using Mvvm.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mvvm.Contracts
{
    public interface INavigationService
    {
        Task NavigateToAsync(Page page);

        Task InitializeAsync();

        Task NavigateToAsync<TViewModel>() where TViewModel : BaseViewModel;

        Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : BaseViewModel;

        Task NavigateToAsync(Type viewModelType);

        Task ClearBackStack();

        Task NavigateToAsync(Type viewModelType, object parameter);

        Task NavigateBackAsync();
    }
}

