using KidsStoriesApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KidsStoriesApp.Services
{
    public class StoriesData : IKidsStoriesListDataStore<KidsStoriesList>
    {
        readonly List<KidsStoriesList> storiesLists;
        public Task<bool> AddStoriesAsync(KidsStoriesList story)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStoriesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetStoriesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<KidsStoriesList>> GetStoriesAsync(bool forceRefresh = false)
        {
            return await App.KidsStoriesDataBase.GetkidsStoriesAsync();
        }

        public Task<bool> UpdateStoriesAsync(KidsStoriesList story)
        {
            throw new NotImplementedException();
        }
    }
}
