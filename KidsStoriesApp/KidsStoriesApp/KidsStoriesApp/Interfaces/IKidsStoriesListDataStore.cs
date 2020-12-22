using KidsStoriesApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KidsStoriesApp.Services
{
    public interface IKidsStoriesDataStore
    {
       Task<List<KidsStoriesListModel>> GetAllStories();
    }
}
