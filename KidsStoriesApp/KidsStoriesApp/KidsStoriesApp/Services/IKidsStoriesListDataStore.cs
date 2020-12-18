using System.Collections.Generic;
using System.Threading.Tasks;

namespace KidsStoriesApp.Services
{
    public interface IKidsStoriesListDataStore<T>
    {
        Task<bool> UpdateStoriesAsync(T story);
        Task<bool> AddStoriesAsync(T story);
        Task<bool> GetStoriesAsync(int id);
        Task<bool> DeleteStoriesAsync(int id);
        Task<IEnumerable<T>> GetStoriesAsync(bool forceRefresh = false);
    }
}
