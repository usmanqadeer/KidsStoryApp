using KidsStoriesApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KidsStoriesApp.Services
{
    public interface IKidsStoriesListDataStore
    {
       Task<List<KidsStoriesListModel>> GetAllStories();
    }
}
