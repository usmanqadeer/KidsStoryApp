using SQLite;

namespace KidsStoriesApp.Models
{
    public class RecordStoriesListModel
    {
        [PrimaryKey, AutoIncrement]
        public int AudioID { get; set; }
        public int StoryID { get; set; }
        public string StoryTitel { get; set; }
        public string AudioStoryPath { get; set; }
    }
}
