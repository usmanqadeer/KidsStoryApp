using KidsStoriesApp.Models;
using KidsStoriesApp.Services;
using System;
using System.Collections.ObjectModel;

namespace KidsStoriesApp.ViewModels
{
    public class StoriesListPageViewModel : BaseViewModel
    {
        public ObservableCollection<KidsStoriesListModel> KidsStories { get; set; }
        private IKidsStoriesDataStore _kidsStoriesListDataStore;
        public StoriesListPageViewModel(IKidsStoriesDataStore kidsStoriesListDataStore)
        {
            KidsStories = new ObservableCollection<KidsStoriesListModel>();
            _kidsStoriesListDataStore = kidsStoriesListDataStore;
            GetStoriesAsync();
        }
        public async void GetStoriesAsync()
        {
            try
            {
                var allStories = await _kidsStoriesListDataStore.GetAllStories();
                foreach (var stories in allStories)
                {
                    KidsStories.Add(stories);
                }
            }
            catch (Exception ex) { }
        }


    }
}
