using SQLite;
using System;
using System.IO;
using System.Reflection;
using KidsStoriesApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KidsStoriesApp.Data
{
    public class KidsStoriesDataBase
    {
        readonly SQLiteAsyncConnection _database;
        public KidsStoriesDataBase()
        {
            string DataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KidsStories.db");
            Assembly assembly = IntrospectionExtensions.GetTypeInfo(typeof(App)).Assembly;
            Stream ambededDataBaseStreem = assembly.GetManifestResourceStream("KidsStoriesApp.KidsStories.db");

            if (!File.Exists(DataBasePath))
            {
                FileStream fileStreamToWrite = File.Create(DataBasePath);
                ambededDataBaseStreem.Seek(0, SeekOrigin.Begin);
                ambededDataBaseStreem.CopyTo(fileStreamToWrite);
                fileStreamToWrite.Close();
            }

            _database = new SQLiteAsyncConnection(DataBasePath);
            _database.CreateTableAsync<KidsStoriesList>().Wait();
            _database.CreateTableAsync<RecordStoriesList>().Wait();

        }

        // Show kidsStories
        public Task<List<KidsStoriesList>> GetkidsStoriesAsync()
        {
            return _database.Table<KidsStoriesList>().ToListAsync();
        }

        // Save kidsStories
        public Task<int> SavekidsStoriesAsync(KidsStoriesList kidsStories)
        {
            return _database.InsertAsync(kidsStories);
        }

        // Delete kidsStories
        public Task<int> DeletekidsStoriesAsync(KidsStoriesList kidsStories)
        {
            return _database.DeleteAsync(kidsStories);
        }

        // Save kidsStories
        public Task<int> UpdatekidsStoriesAsync(KidsStoriesList kidsStories)
        {
            return _database.UpdateAsync(kidsStories);
        }
    }
}
