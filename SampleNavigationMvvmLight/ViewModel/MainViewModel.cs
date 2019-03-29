using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SampleNavigationMvvmLight.View;

namespace SampleNavigationMvvmLight.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private RelayCommand _loadedCommand;
        private INavigationService<NavigationPage> _navigationService;

        public MainViewModel(INavigationService<NavigationPage> navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand LoadedCommand
        {
            get
            {
                return _loadedCommand
                    ?? (_loadedCommand = new RelayCommand(
                    () =>
                    {
                        _navigationService.NavigateTo("Home");
                    }));
            }
        }
    }
}