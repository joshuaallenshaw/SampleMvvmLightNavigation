using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SampleNavigationMvvmLight.View;

namespace SampleNavigationMvvmLight.ViewModel
{
    public class Page2ViewModel : ViewModelBase
    {
        private RelayCommand _homeCommand;
        private INavigationService<NavigationPage> _navigationService;
        private string _page2Text = "Page 2";

        public Page2ViewModel(INavigationService<NavigationPage> navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand HomeCommand => _homeCommand
                       ?? (_homeCommand = new RelayCommand(
                           () => _navigationService.NavigateTo("Home")));

        public string Page2Text
        {
            get => _page2Text;
            set => Set(ref _page2Text, value);
        }
    }
}