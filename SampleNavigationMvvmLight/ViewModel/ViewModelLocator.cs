/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:Chargily.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>

  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using SampleNavigationMvvmLight.View;

namespace SampleNavigationMvvmLight.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the application and provides
    /// an entry point for the bindings.
    /// <para>See http://www.mvvmlight.net</para>
    /// </summary>
    public class ViewModelLocator
    {
        private static bool initialized;

        public ViewModelLocator()
        {
            //Fix to keep blend happy
            if (initialized) { return; }
            initialized = true;

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<Page2ViewModel>();
            SimpleIoc.Default.Register<Page1ViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
            SetupNavigation();
        }

        public HomeViewModel HomeViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public Page1ViewModel Page1ViewModel => ServiceLocator.Current.GetInstance<Page1ViewModel>();

        public Page2ViewModel Page2ViewModel => ServiceLocator.Current.GetInstance<Page2ViewModel>();

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
        }

        private void SetupNavigation()
        {
            var navigationService = new NavigationService<NavigationPage>();
            navigationService.ConfigurePages();
            SimpleIoc.Default.Register<INavigationService<NavigationPage>>(() => navigationService);
        }
    }
}