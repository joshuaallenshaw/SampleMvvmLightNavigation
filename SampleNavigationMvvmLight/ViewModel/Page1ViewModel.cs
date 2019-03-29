using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SampleNavigationMvvmLight.View;

namespace SampleNavigationMvvmLight.ViewModel
{
    public class Page1ViewModel : ViewModelBase
    {
        private RelayCommand _homeCommand;
        private INavigationService<NavigationPage> _navigationService;
        private string _page1Text = "Page 1";

        public Page1ViewModel(INavigationService<NavigationPage> navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand HomeCommand => _homeCommand
                    ?? (_homeCommand = new RelayCommand(
                    () => _navigationService.NavigateTo("Home")));

        public string Page1Text
        {
            get => _page1Text;

            set => Set(ref _page1Text, value);
        }
    }
}