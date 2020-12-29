using KidsStoriesApp.Models;
using KidsStoriesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsStoriesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoriesListPage : ContentPage
    {
        StoriesListPageViewModel storiesListPageViewModel = new StoriesListPageViewModel();
        public StoriesListPage()
        {
            InitializeComponent();
            this.BindingContext = new StoriesListPageViewModel();
        }
        private async void BtnDeleteStory_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var kidsStoriesListModel = (sender as View).BindingContext as KidsStoriesListModel;
                var _storyID = await App.KidsStoriesDataBase.DeletekidsStoriesAsync(kidsStoriesListModel);
                if (_storyID > 0)
                {
                    storiesListPageViewModel.GetStoriesAsync();
                    await DisplayAlert("Deleted!!", "Story Delete succesfully","No", "ok");
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        private async void BtnUpdate_Clicked(object sender, System.EventArgs e)
        {
            var kidsStoriesListModel = (sender as View).BindingContext as KidsStoriesListModel;
            await this.Navigation.PushAsync(new AddNewStoryPage(kidsStoriesListModel));
        }

        private async void btnRecordingNewStory_Clicked(object sender, System.EventArgs e)
        {
            var kidsStoriesListModel = (sender as View).BindingContext as KidsStoriesListModel;
            await this.Navigation.PushAsync(new SelectedStoryPage(kidsStoriesListModel));
        }

        private async void btnBack_Clicked(object sender, System.EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
    }
}