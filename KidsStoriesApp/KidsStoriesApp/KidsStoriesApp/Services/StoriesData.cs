using KidsStoriesApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KidsStoriesApp.Services
{
    public class StoriesData : IKidsStoriesListDataStore
    {
        public async Task<List<KidsStoriesListModel>> GetAllStories()
        {
            return await App.KidsStoriesDataBase.GetkidsStoriesAsync();
        }
    }
}
