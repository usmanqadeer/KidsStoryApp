using SQLite;

namespace KidsStoriesApp.Models
{
    public class KidsStoriesList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string StoryText { get; set; }
    }
}
