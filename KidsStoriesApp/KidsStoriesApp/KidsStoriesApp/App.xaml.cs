using CommonServiceLocator;
using KidsStoriesApp.Data;
using KidsStoriesApp.Interfaces;
using KidsStoriesApp.Services;
using KidsStoriesApp.Views;
using Unity;
using Unity.ServiceLocation;
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
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<IKidsStoriesDataStore, StoriesData>();
            unityContainer.RegisterType<IPlayListDataStore, PlayListData>();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(unityContainer));

            MainPage = new NavigationPage(new SelectedStoryPage());
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
