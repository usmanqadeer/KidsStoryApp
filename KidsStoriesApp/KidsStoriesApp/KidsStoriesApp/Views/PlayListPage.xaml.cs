using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsStoriesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayListPage : ContentPage
    {
        ItemList ItemList = new ItemList();
        public PlayListPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        public List<ItemList> PropertyTypeList => ItemList.AllStories();
    }
}