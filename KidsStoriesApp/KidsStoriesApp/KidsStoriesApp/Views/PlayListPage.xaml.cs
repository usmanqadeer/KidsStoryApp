using CommonServiceLocator;
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
            BindingContext = ServiceLocator.Current.GetInstance(typeof(KidsStoriesListViewModel));
        }
    }
}