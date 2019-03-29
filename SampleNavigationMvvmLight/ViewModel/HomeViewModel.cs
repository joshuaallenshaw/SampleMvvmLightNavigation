using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SampleNavigationMvvmLight.View;

namespace SampleNavigationMvvmLight.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        private string _myProperty = "MainPageText";
        private INavigationService<NavigationPage> _navigationService;
        private RelayCommand _page1Command;

        private RelayCommand _page2Command;

        public HomeViewModel(INavigationService<NavigationPage> navigationService)
        {
            _navigationService = navigationService;
        }

        public string MainPageText
        {
            get => _myProperty;
            set => Set(ref _myProperty, value);
        }

        public RelayCommand Page1Command => _page1Command
                    ?? (_page1Command = new RelayCommand(
                    () => _navigationService.NavigateTo("Page1")));

        public RelayCommand Page2Command => _page2Command
                       ?? (_page2Command = new RelayCommand(
                           () => _navigationService.NavigateTo("Page2")));
    }
}