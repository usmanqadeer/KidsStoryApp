using KidsStoriesApp.Models;
using MediaManager;
using Plugin.AudioRecorder;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsStoriesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayAudioPage : ContentPage
    {
        private TimeSpan duration;
        public TimeSpan Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                OnPropertyChanged();
            }
        }

        private TimeSpan position;
        public TimeSpan Position
        {
            get { return position; }
            set
            {
                position = value;
                OnPropertyChanged();
            }
        }

        double maximum = 100f;
        public double Maximum
        {
            get { return maximum; }
            set
            {
                if (value > 0)
                {
                    maximum = value;
                    OnPropertyChanged();
                }
            }
        }
        private bool isPlaying;
        public bool IsPlaying
        {
            get { return isPlaying; }
            set
            {
                isPlaying = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(PlayIcon));
            }
        }

        public string PlayIcon { get => isPlaying ? "Start.png" : "Stop.png"; }

        public RecordStoriesListModel RecordStoriesListModel { get; set; }
        AudioPlayer player = new AudioPlayer();
        public PlayAudioPage(RecordStoriesListModel recordStoriesListModel)
        {
            InitializeComponent();
            this.BindingContext = this;
            RecordStoriesListModel = recordStoriesListModel;
            DataBinding();
            
        }
        public PlayAudioPage()
        {
            InitializeComponent();
        }

        private async void btnBack_Clicked(object sender, EventArgs e)
        {
            await this.Navigation.PopAsync();
        }
        private async void DataBinding()
        {
            try
            {

                int story_id = RecordStoriesListModel.StoryID;
                var stories = await App.KidsStoriesDataBase.GetkidsStoriesAsync();
                foreach (var story in stories)
                {
                    if (story.StoryID == story_id)
                    {
                        txtStoryTitle.Text = story.StoryTitel;
                        txtStoryText.Text = story.StoryText;
                        PlayStory();
                        return;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
          
        }
        private async void PlayStory()
        {
            try
            {
                var mediaInfo = CrossMediaManager.Current;
                await CrossMediaManager.Current.Play(RecordStoriesListModel.AudioStoryPath);
                Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
                {
                    Duration = mediaInfo.Duration;
                    Maximum = duration.TotalSeconds;
                    Position = mediaInfo.Position;
                    return true;
                });
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async  void bntplay_Clicked(object sender, EventArgs e)
        {
            var mediaInfo = CrossMediaManager.Current;
            await mediaInfo.Play(RecordStoriesListModel.AudioStoryPath);
            IsPlaying = true;

            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                Duration = mediaInfo.Duration;
                Maximum = duration.TotalSeconds;
                Position = mediaInfo.Position;
                return true;
            });
        }
        
        private async void bntStop_Clicked(object sender, EventArgs e)
        {
            if (isPlaying)
            {
                await CrossMediaManager.Current.Pause();
                IsPlaying = false; ;
            }
            else
            {
                await CrossMediaManager.Current.Play();
                IsPlaying = true; ;
            }
           
        }
    }
}