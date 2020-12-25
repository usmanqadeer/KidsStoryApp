using CommonServiceLocator;
using KidsStoriesApp.Models;
using KidsStoriesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsStoriesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoriesListPage : ContentPage
    {
        private int id;
        private string storyName;
        private string storyTitel;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string StoryText
        {
            get { return storyName; }
            set { storyName = value; }
        }
        public StoriesListPage()
        {

            InitializeComponent();
            BindingContext = ServiceLocator.Current.GetInstance(typeof(StoriesListPageViewModel));
        }
       
        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new SelectedStoryPage(storyName));
        }

    }
}