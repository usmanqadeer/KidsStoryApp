using KidsStoriesApp.Interfaces;
using KidsStoriesApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KidsStoriesApp.Services
{
    public class PlayListData : IPlayListDataStore
    {
        public async Task<List<RecordStoriesListModel>> GetAllPlayList()
        {
            return await App.KidsStoriesDataBase.GetAllPlayListAsync();
        }
    }
}
