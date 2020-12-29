using KidsStoriesApp.Models;
using KidsStoriesApp.Views;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace KidsStoriesApp.ViewModels
{
    public class StoriesListPageViewModel : BaseViewModel
    {
        //public ObservableCollection<KidsStoriesListModel> KidsStories { get; private set; }
        private ObservableCollection<KidsStoriesListModel> _KidsStories;

        public ObservableCollection<KidsStoriesListModel> KidsStories
        {
            get { return _KidsStories; }
            set { _KidsStories = value; OnPropertyChanged("KidsStories"); }
        }

        public Command NavigateCommand { get; private set; }
        public Command NavigateBackCommand { get; private set; }
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; OnPropertyChanged("ID"); }
        }
        private string _storyTitel;

        public string StoryTitel
        {
            get { return _storyTitel; }
            set { if (_storyTitel != null) _storyTitel = value; OnPropertyChanged("StoryTitel"); }
        }
        private string _storyText;
        public string StoryText
        {
            get { return _storyText; }
            set {if(_storyText != null) _storyText = value; OnPropertyChanged("StoryText"); }
        }
        public StoriesListPageViewModel()
        {
            this.KidsStories = new ObservableCollection<KidsStoriesListModel>();
            NavigateCommand = new Command(AddStory);
            GetStoriesAsync();
        }
        public  async void GetStoriesAsync()
        {
            try
            {
                var allStories = await App.KidsStoriesDataBase.GetkidsStoriesAsync();
                foreach (var stories in allStories)
                {
                    _KidsStories.Add(stories);
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
