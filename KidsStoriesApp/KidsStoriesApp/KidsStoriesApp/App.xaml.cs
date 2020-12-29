using KidsStoriesApp.Data;
using KidsStoriesApp.Views;
using Xamarin.Forms;
using System;
using System.IO;

namespace KidsStoriesApp
{
    public partial class App : Application
    {
        private static KidsStoriesDataBase storiesDataBase;
        public static void CreateAudioDirectory()
        {
            string audio_dir = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AudioFiles");
            if (!Directory.Exists(audio_dir))
                Directory.CreateDirectory(audio_dir);
        }

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
