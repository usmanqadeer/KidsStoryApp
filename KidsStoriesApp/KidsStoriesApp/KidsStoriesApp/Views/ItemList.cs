using System.Collections.Generic;

namespace KidsStoriesApp.Views
{
    public class ItemList
    {
        List<ItemList> itemLists = new List<ItemList>();
        public int PlayID { get; set; }
        public string StoryTitel { get; set; }
       
        public List<ItemList> AllStories()
        {
            List<ItemList> itemList = new List<ItemList>()
        {
            new ItemList{PlayID = 1, StoryTitel ="As you design your document and make formatting decisions, you will need to consider line and paragraph spacing."},
            new ItemList{PlayID = 2, StoryTitel ="As you design your document and make formatting decisions, you will need to consider line and paragraph spacing."},
            new ItemList{PlayID = 3, StoryTitel ="As you design your document and make formatting decisions, you will need to consider line and paragraph spacing."}
        };
            List<ItemList> lists = itemList;
            foreach(ItemList item in lists)
            {
                itemLists.Add(item);
            }
            return itemLists;
        }
    }
}
