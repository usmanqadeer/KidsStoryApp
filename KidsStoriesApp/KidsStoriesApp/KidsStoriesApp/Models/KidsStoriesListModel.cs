using SQLite;

namespace KidsStoriesApp.Models
{
    public class KidsStoriesListModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string StoryTitel { get; set; }
        public string StoryText { get; set; }
    }
}
