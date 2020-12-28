using KidsStoriesApp.Models;
using KidsStoriesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsStoriesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayListPage : ContentPage
    {
        public PlayListPage()
        {
            InitializeComponent();
            this.BindingContext = new PlayListPageViewModel(Navigation);
            
        }

        private async void btnBack_Clicked(object sender, System.EventArgs e)
        {
            await  this.Navigation.PopAsync();
        }

        private async void btnDeleteAudio_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                var RecordStoriesListModel = (sender as View).BindingContext as RecordStoriesListModel;
                var _storyID = await App.KidsStoriesDataBase.DeletekidsRecordStoriesAsync(RecordStoriesListModel);
                if (_storyID > 0)
                {
                   await DisplayAlert("Deleted!!", "Story Delete succesfully","Cancel", "ok");
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        private async void btnPlayStory_Clicked(object sender, System.EventArgs e)
        {
            try
            { 
                var kidsRecordStoriesListModel = (sender as View).BindingContext as RecordStoriesListModel;
                await this.Navigation.PushAsync(new PlayAudioPage(kidsRecordStoriesListModel));
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        private async void btnAddNew_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new StoriesListPage());
        }
    }
}