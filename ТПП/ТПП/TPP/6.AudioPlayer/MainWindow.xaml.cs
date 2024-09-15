using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace _6.AudioPlayer
{
    public class Track
    {
        public required string TrackName { get; set; }
        public required string TrackPath { get; set; }
    }

    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private readonly MediaPlayer mediaPlayer = new();
        private bool _isPlaying = false;
        private int _playingIndex = 0;

        public DispatcherTimer Timer { get; set; }
        public ObservableCollection<Track> Playlist { get; set; } = [];
        public Track MouseOnTrack { get; set; }



        private double _currentPosition;

        public double CurrentPosition
        {
            get => _currentPosition;
            set 
            { 
                _currentPosition = value; 
                OnPropertyChanged(nameof(CurrentPosition));
                
            }
        }

        private double _currentMaximumPosition;

        public double CurrentMaximumPosition
        {
            get => _currentMaximumPosition;
            set
            {
                _currentMaximumPosition = value;
                OnPropertyChanged(nameof(CurrentMaximumPosition));
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Timer = new()
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            Timer.Tick += TimerTick;
            Timer.Start();
        }


        private void addToListButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Title = "Выберите аудиофайл",
                Filter = "MP3 files (*.mp3)|*.mp3|WAV files (*.wav)|*.wav"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                Playlist.Add(new() { TrackName = openFileDialog.SafeFileName, TrackPath = openFileDialog.FileName });
                if (Playlist.Count > 1) return;
                mediaPlayer.Open(new Uri(openFileDialog.FileName));
            }
        }

        private void playPauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (_playingIndex == Playlist.Count - 1)
            {
                mediaPlayer.Close();
                _playingIndex = 0;
                mediaPlayer.Open(new Uri(Playlist[0].TrackPath));
                mediaPlayer.Play();
                _isPlaying = true;
                return;
            }
            if (_isPlaying)
            {
                mediaPlayer.Pause();
                _isPlaying = false;
            }
            else
            {
                mediaPlayer.Play();
                _isPlaying = true;
                
            }
        }

        private void skipButton_Click(object sender, RoutedEventArgs e)
        {
            NextTrack();
        }

        private void LBPlayButton_Click(object sender, RoutedEventArgs e)
        {
            _playingIndex = Playlist.IndexOf(Playlist.First(x => x == MouseOnTrack));
            mediaPlayer.Open(new Uri(MouseOnTrack.TrackPath));
            mediaPlayer.Play();
            _isPlaying = true;
            
        }

        private void LBRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.Close();
            Playlist.Remove(MouseOnTrack);
            _isPlaying = false;
        }

        private void PlaylistItem_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            MouseOnTrack = (Track)((StackPanel)sender).DataContext;
        }

        void TimerTick(object? sender, EventArgs e)
        {
            if (!mediaPlayer.NaturalDuration.HasTimeSpan) return;
            if (mediaPlayer.Source != null)
            {
                textStatus.Content = string.Format("{0} / {1}", mediaPlayer.Position.ToString(@"mm\:ss"), mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
                if (_playingIndex < Playlist.Count)
                    songTitle.Content = Playlist[_playingIndex].TrackName;
                CurrentPosition = mediaPlayer.Position.TotalMilliseconds;
                CurrentMaximumPosition = mediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
            }
            if (CurrentPosition == mediaPlayer.NaturalDuration.TimeSpan.TotalMilliseconds)
            {
                NextTrack();
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mediaPlayer.Position = TimeSpan.FromMilliseconds(Slider.Value);
        }
        private void NextTrack()
        {
            if (_playingIndex < Playlist.Count - 1)
            {
                _playingIndex++;
                mediaPlayer.Close();
                mediaPlayer.Open(new Uri(Playlist[_playingIndex].TrackPath));
                mediaPlayer.Play();
            }
        }

        private void SavePlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            string playlist = "";
            foreach (var item in Playlist)
                playlist += item.TrackPath + "#" + item.TrackName + "\n";
            SaveFileDialog saveFileDialog = new()
            {
                Title = "Сохранить",
                Filter = "Text file (*.txt)|*.txt"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, playlist);
                MessageBox.Show($"Плейлист сохранен по пути {saveFileDialog.FileName}");
            }
        }

        private void OpenPlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            Playlist.Clear();
            OpenFileDialog openFileDialog = new()
            {
                Title = "Открыть",
                Filter = "Text file (*.txt)|*.txt"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                List<string> playlist = [.. File.ReadAllLines(openFileDialog.FileName)];
                foreach (var item in playlist)
                {
                    var indexOfSeparator = item.IndexOf(item.First(x => x == '#'));
                    var track = new Track
                    {
                        TrackPath = item[..indexOfSeparator],
                        TrackName = item.Substring(indexOfSeparator + 1, item.Length - indexOfSeparator - 1)
                    };
                    Playlist.Add(track);
                }
                mediaPlayer.Open(new Uri(Playlist[0].TrackPath));
                MessageBox.Show($"Плейлист успешно импортирован!");

            }
        }
    }
}