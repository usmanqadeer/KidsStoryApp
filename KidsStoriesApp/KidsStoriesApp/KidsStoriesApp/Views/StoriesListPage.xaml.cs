using CommonServiceLocator;
using KidsStoriesApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsStoriesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoriesListPage : ContentPage
    {
        public StoriesListPage()
        {
            InitializeComponent();
            BindingContext = ServiceLocator.Current.GetInstance(typeof(StoriesListPageViewModel));
        }
    }
}