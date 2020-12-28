using KidsStoriesApp.Models;
using KidsStoriesApp.Views;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace KidsStoriesApp.ViewModels
{
    public class StoriesListPageViewModel : BaseViewModel
    {
        public ObservableCollection<KidsStoriesListModel> KidsStories { get; private set; }
        public Command NavigateCommand { get; private set; }
        public Command NavigateBackCommand { get; private set; }
        private INavigation navigation;

        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _storyTitel;

        public string StoryTitel
        {
            get { return _storyTitel; }
            set { _storyTitel = value; }
        }
        private string _storyText;
        public string StoryText
        {
            get { return _storyText; }
            set { _storyText = value; }
        }
        public StoriesListPageViewModel(INavigation _navigation)
        {
            this.KidsStories = new ObservableCollection<KidsStoriesListModel>();
            this.navigation = _navigation;
            NavigateCommand = new Command(AddStory);
            GetStoriesAsync();
        }
        public async void GetStoriesAsync()
        {
            try
            {
                var allStories = await App.KidsStoriesDataBase.GetkidsStoriesAsync();
                foreach (var stories in allStories)
                {
                    KidsStories.Add(stories);
                }
            }
            catch (Exception ex) { }
        }
        private async void AddStory()
        {
            var addStoryPage = new AddNewStoryPage();
            var navigation = Application.Current.MainPage as NavigationPage;
            await navigation.PushAsync(addStoryPage, true);
        }

    }
}
