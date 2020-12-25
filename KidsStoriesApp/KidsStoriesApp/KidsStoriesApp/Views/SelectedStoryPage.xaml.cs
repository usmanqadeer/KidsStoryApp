using KidsStoriesApp.ViewModels;
using Plugin.AudioRecorder;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsStoriesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedStoryPage : ContentPage
    {
        AudioRecorderService recorder;
        AudioPlayer player;
        private string file_name;
        bool isTimerRunning = false;
        int seconds = 0, minutes = 0;
        private string _storyText;

        public string StoryText
        {
            get { return _storyText; }
            set { _storyText = value; }
        }

        public SelectedStoryPage(string storyText)
        {
            InitializeComponent();
            this.BindingContext = this;
            _storyText = storyText;
            if (Device.RuntimePlatform == Device.iOS)
                this.Padding = new Thickness(0, 28, 0, 0);

            recorder = new AudioRecorderService
            {
                StopRecordingAfterTimeout = true,
                TotalAudioTimeout = TimeSpan.FromSeconds(15),
                AudioSilenceTimeout = TimeSpan.FromSeconds(2)
            };

            player = new AudioPlayer();
            player.FinishedPlaying += Finish_Playing;
        }
        void Finish_Playing(object sender, EventArgs e)
        {
            bntRecord.IsEnabled = true;
            bntRecord.BackgroundColor = Color.FromHex("#7cbb45");
            bntPlay.IsEnabled = true;
            bntPlay.BackgroundColor = Color.FromHex("#7cbb45");
            bntStop.IsEnabled = false;
            bntStop.BackgroundColor = Color.Silver;
            lblSeconds.Text = "00";
            lblMinutes.Text = "00";
        }

        async void bntRecord_Clicked(object sender, EventArgs e)
        {
            if (!recorder.IsRecording)
            {
                seconds = 0;
                minutes = 0;
                isTimerRunning = true;
                Device.StartTimer(TimeSpan.FromSeconds(1), () => {
                    seconds++;

                    if (seconds.ToString().Length == 1)
                    {
                        lblSeconds.Text = "0" + seconds.ToString();
                    }
                    else
                    {
                        lblSeconds.Text = seconds.ToString();
                    }
                    if (seconds == 60)
                    {
                        minutes++;
                        seconds = 0;

                        if (minutes.ToString().Length == 1)
                        {
                            lblMinutes.Text = "0" + minutes.ToString();
                        }
                        else
                        {
                            lblMinutes.Text = minutes.ToString();
                        }

                        lblSeconds.Text = "00";
                    }
                    return isTimerRunning;
                });

                //
                recorder.StopRecordingOnSilence = IsSilence.IsToggled;
                var recordTask = await recorder.StartRecording();
                file_name = recordTask.ToString();
                
                bntRecord.IsEnabled = false;
                bntRecord.BackgroundColor = Color.Silver;
                bntPlay.IsEnabled = false;
                bntPlay.BackgroundColor = Color.Silver;
                bntStop.IsEnabled = true;
                bntStop.BackgroundColor = Color.FromHex("#7cbb45");

                await recordTask;
            }
        }
        void StopRecording()
        {
            isTimerRunning = false;
            bntRecord.IsEnabled = true;
            bntRecord.BackgroundColor = Color.FromHex("#7cbb45");
            bntPlay.IsEnabled = true;
            bntPlay.BackgroundColor = Color.FromHex("#7cbb45");
            bntStop.IsEnabled = false;
            bntStop.BackgroundColor = Color.Silver;
            lblSeconds.Text = "00";
            lblMinutes.Text = "00";
        }

        private async void bntStop_Clicked(object sender, EventArgs e)
        {
            StopRecording();
            
            await recorder.StopRecording();
        }

        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            if(file_name != null)
            {
               var audio_id = await App.KidsStoriesDataBase.SaveAudioAsync(new Models.RecordStoriesListModel {AudioStoryPath = file_name,StoryTitel = "Testing"});
                if(audio_id > 0)
                {
                    await DisplayAlert("Success","Record enter..","ok");
                }
            }
        }

        void bntPlay_Clicked(object sender, EventArgs e)
        {
            try
            {
                var filePath = recorder.GetAudioFilePath();
                if (filePath != null)
                {
                    StopRecording();
                    player.Play(filePath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}