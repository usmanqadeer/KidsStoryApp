using KidsStoriesApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsStoriesApp.Views
{
    [DesignTimeVisible(false)]
    public partial class MainMenuPage : ContentPage
    {
        public MainMenuPage()
        {
            InitializeComponent();
            BindingContext = new MainPageViewModel(Navigation);
        }

        private void BtnExit_Clicked(object sender, System.EventArgs e)
        {
            System.Environment.Exit(0);
        }

        
    }
}