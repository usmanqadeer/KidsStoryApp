using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace KidsStoriesApp.Models
{
    public class RecordStoriesList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string AudioStoryPath { get; set; }
    }
}
