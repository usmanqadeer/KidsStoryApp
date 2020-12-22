using KidsStoriesApp.Interfaces;
using KidsStoriesApp.Models;
using System;
using System.Collections.ObjectModel;

namespace KidsStoriesApp.ViewModels
{
    public class PlayListPageViewModel
    {
        public ObservableCollection<RecordStoriesListModel> PlayListStories { get; set; }
        private IPlayListDataStore _playListStoriesListDataStore;
        public PlayListPageViewModel(IPlayListDataStore playListDataStore)
        {
            PlayListStories = new ObservableCollection<RecordStoriesListModel>();
            _playListStoriesListDataStore = playListDataStore;
            GetPlayListAsync();
        }
        public async void GetPlayListAsync()
        {
            try
            {
                var allStories = await _playListStoriesListDataStore.GetAllPlayList();
                foreach (var stories in allStories)
                {
                    PlayListStories.Add(stories);
                }
            }
            catch (Exception ex) { }
        }
    }
}
