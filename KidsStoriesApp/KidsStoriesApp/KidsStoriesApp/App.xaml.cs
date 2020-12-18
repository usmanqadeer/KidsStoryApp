using KidsStoriesApp.Data;
using KidsStoriesApp.Views;
using Xamarin.Forms;

namespace KidsStoriesApp
{
    public partial class App : Application
    {
        private static KidsStoriesDataBase storiesDataBase;

        public static  KidsStoriesDataBase KidsStoriesDataBase
        {
            get
            {
                if (storiesDataBase == null)
                {
                    storiesDataBase = new KidsStoriesDataBase();
                }
                return storiesDataBase;
            }

        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainMenuPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
