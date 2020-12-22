using KidsStoriesApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KidsStoriesApp.Services
{
    public class StoriesData : IKidsStoriesDataStore
    {
        public async Task<List<KidsStoriesListModel>> GetAllStories()
        {
            return await App.KidsStoriesDataBase.GetkidsStoriesAsync();
        }
    }
}
