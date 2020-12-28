using KidsStoriesApp.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace KidsStoriesApp.ViewModels
{
    public class PlayListPageViewModel
    {
        public ObservableCollection<RecordStoriesListModel> PlayListStories { get; set; }
        private INavigation navigation;
        public PlayListPageViewModel(INavigation navigation)
        {
            PlayListStories = new ObservableCollection<RecordStoriesListModel>();
            this.navigation = navigation;
            GetPlayListAsync();
        }
        public async void GetPlayListAsync()
        {
            try
            {
                var allStories = await App.KidsStoriesDataBase.GetAllPlayListAsync();
                foreach (var stories in allStories)
                {
                    PlayListStories.Add(stories);
                }
            }
            catch (Exception ex) { }
        }
    }
}
