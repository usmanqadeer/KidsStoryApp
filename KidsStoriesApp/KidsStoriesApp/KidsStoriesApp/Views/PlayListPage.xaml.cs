using KidsStoriesApp.Data;
using KidsStoriesApp.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsStoriesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayListPage : ContentPage
    {
        KidsStoriesDataBase kidsStories = new KidsStoriesDataBase();
        public PlayListPage()
        {
            InitializeComponent();
            this.BindingContext = this;
        }
       
    }
}