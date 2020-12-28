using KidsStoriesApp.Models;
using Plugin.AudioRecorder;
using System;
using System.ComponentModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KidsStoriesApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectedStoryPage : ContentPage, INotifyPropertyChanged
    {
        AudioRecorderService recorder;
        AudioPlayer player;
        string story_title = "";
        private string file_name;
        string file_path;
        bool isTimerRunning = false;
        int seconds = 0, minutes = 0;
        public KidsStoriesListModel storiesListModel { get; set; }
        private int _ID;

        public int StoryID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged("StoryID"); }
        }
        private string _storyTitel;

        public string StoryTitel
        {
            get { return _storyTitel; }
            set { _storyTitel = value; OnPropertyChanged("StoryTitel"); }
        }
        private string _storyTest;

        public string StoryText
        {
            get { return _storyTest; }
            set { _storyTest = value; OnPropertyChanged("StoryText"); }
        }
       
        public SelectedStoryPage(KidsStoriesListModel kidsStoriesListModel)
        {
            InitializeComponent();
            this.BindingContext = this;
            this.storiesListModel = kidsStoriesListModel;
            _ID = storiesListModel.StoryID;
            _storyTest = storiesListModel.StoryText;
            _storyTitel = storiesListModel.StoryTitel;
            recorder = new AudioRecorderService
            {
                StopRecordingAfterTimeout = true,
                TotalAudioTimeout = TimeSpan.FromSeconds(15),
                AudioSilenceTimeout = TimeSpan.FromSeconds(2)
            };
            recorder.AudioInputReceived += Recorder_OnInputRecieved;
            ShowData();
            player = new AudioPlayer();
            player.FinishedPlaying += Finish_Playing;
        }
        private void ShowData()
        {
            story_title = StoryTitel;
            txtStoryTitel.Text = story_title;
            txtStoryText.Text = StoryText;
        }
        private void Finish_Playing(object sender, EventArgs e)
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

        private async void bntRecord_Clicked(object sender, EventArgs e)
        {
            //recorder.FilePath = "AudioFiles/";
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
                recorder.StopRecordingOnSilence = IsSilence.IsToggled;
                var recordTask = await recorder.StartRecording();

                

                
                bntRecord.IsEnabled = false;
                bntRecord.BackgroundColor = Color.Silver;
                bntPlay.IsEnabled = false;
                bntPlay.BackgroundColor = Color.Silver;
                bntStop.IsEnabled = true;
                bntStop.BackgroundColor = Color.FromHex("#7cbb45");

                await recordTask;
            }
        }
        private void StopRecording()
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
            file_name = story_title;
            
            
            await recorder.StopRecording();
        }
        private async void btnSave_Clicked(object sender, EventArgs e)
        {
            string dir_path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AudioFiles");
            if (!Directory.Exists(dir_path))
                Directory.CreateDirectory(dir_path);

            string new_file_path = dir_path + "/" + file_name + ".wav";

            if (File.Exists(new_file_path))
                File.Delete(new_file_path);

            File.Copy(file_path, new_file_path);
                        
            var audio_id = await App.KidsStoriesDataBase.SaveAudioAsync(new Models.RecordStoriesListModel {StoryID = _ID, AudioStoryPath = new_file_path });
                
            if(audio_id > 0)
            {
                await DisplayAlert("Successfully!","Recording  Save successfully","ok");
            }
        }

        private void bntPlay_Clicked(object sender, EventArgs e)
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

        private void Recorder_OnInputRecieved(object sender, string audio_file)
        {
            file_path = audio_file;
        }
    }
}