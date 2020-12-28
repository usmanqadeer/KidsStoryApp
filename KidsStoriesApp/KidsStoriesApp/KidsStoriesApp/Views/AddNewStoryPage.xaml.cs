using KidsStoriesApp.Models;
using KidsStoriesApp.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsStoriesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddNewStoryPage : ContentPage
    {

        public KidsStoriesListModel KidsStoriesListModel { get; set; }
        public AddNewStoryPage(KidsStoriesListModel kidsStoriesListModel)
        {
            InitializeComponent();
            KidsStoriesListModel = kidsStoriesListModel;
            this.BindingContext = new AddNewStoryPageViewModel();
            DataBinding();
        }

        public AddNewStoryPage()
        {
            InitializeComponent();
        }

        private void BtnClear_Clicked(object sender, EventArgs e)
        {
            txtStoryText.Text = string.Empty;
            txtStoryTitel.Text = string.Empty;
        }
        private void DataBinding()
        {
            txtStoryTitel.Text = KidsStoriesListModel.StoryTitel;
            txtStoryText.Text = KidsStoriesListModel.StoryText;
            txtStoryID.Text = KidsStoriesListModel.StoryID.ToString();
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            try
            {
                var story_id = await App.KidsStoriesDataBase.SavekidsStoriesAsync(new KidsStoriesListModel { StoryTitel = txtStoryTitel.Text, StoryText = txtStoryText.Text });
                if (story_id > 0)
                {
                    await DisplayAlert("Successfully", "Story Enter Successfully!", "ok");
                    txtStoryText.Text = string.Empty;
                    txtStoryTitel.Text = string.Empty;
                    txtStoryID.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private async void ButUpdate_Clicked(object sender, EventArgs e)
        {
            try
            {
                var id = await App.KidsStoriesDataBase.UpdatekidsStoriesAsync(new KidsStoriesListModel { StoryID = Convert.ToInt32(txtStoryID.Text), StoryTitel = txtStoryTitel.Text, StoryText = txtStoryText.Text });

                if (id > 0)
                {
                    await DisplayAlert("Successfully", "Story Update Successfully!", "ok");
                    txtStoryText.Text = string.Empty;
                    txtStoryTitel.Text = string.Empty;
                    txtStoryID.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        private async void btnback_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
    }
}