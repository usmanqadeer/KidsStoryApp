using KidsStoriesApp.Views;
using Xamarin.Forms;

namespace KidsStoriesApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public Command NavigateToPlayList { get; set; }
        public Command NavigateToStories { get; set; }
        private INavigation _navigation;
        public MainPageViewModel(INavigation navigation)
        {
            NavigateToPlayList = new Command(NaviGateToPlayListPage);
            NavigateToStories = new Command(NavigateToStoriesListPage);
           _navigation = navigation;
            
        }

        private void NavigateToStoriesListPage()
        {
            _navigation.PushAsync(new StoriesListPage());
        }

        private void NaviGateToPlayListPage()
        {
            _navigation.PushAsync(new PlayListPage());
        }
    }
}
