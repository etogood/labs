using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace _5.Notepad
{
    public class ActionCommand(Action action) : ICommand
    {
        private readonly Action _action = action;

        public void Execute(object parameter)
        {
            _action();
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int _currentFontSize = 14;

        public int CurrentFontSize
        {
            get { return _currentFontSize; }
            set
            {
                _currentFontSize = value;
                OnPropertyChanged(nameof(CurrentFontSize));
            }
        }


        private ICommand _saveCommand;
        public ICommand SaveCommand => _saveCommand ??= new ActionCommand(SaveText);

        private ICommand _newFileCommand;
        public ICommand NewFileCommand => _newFileCommand ??= new ActionCommand(NewFile);

        private ICommand _openFileCommand;
        public ICommand OpenFileCommand => _openFileCommand ??= new ActionCommand(OpenFile);

        private bool _isSaved = false;

        private string _path = string.Empty;

        private string Asterisk => FileHasChanges ? "*" : "";

        public string FileNameWithAsterisk
        {
            get => Asterisk + FileName;
            set
            {
                OnPropertyChanged(nameof(FileNameWithAsterisk));
                FileHasChanges = true;
            }
            
        }

        private string _fileName = "Безымянный.txt";
        public string FileName
        {
            get => _fileName; 
            set 
            { 
                _fileName = value;
                OnPropertyChanged(nameof(FileName));
                OnPropertyChanged(nameof(FileNameWithAsterisk));
                FileHasChanges = true;
            }
        }

        private bool _fileHasChanges = true;
        public bool FileHasChanges 
        { 
            get => _fileHasChanges; 
            set
            {
                _fileHasChanges = value;
                OnPropertyChanged(nameof(FileHasChanges));
                OnPropertyChanged(nameof(FileNameWithAsterisk));
            }
        }

        private string _mainText;

        public string MainText
        {
            get => _mainText;
            set 
            { 
                _mainText = value;
                OnPropertyChanged(nameof(MainText));
                FileHasChanges = true;
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveText()
        {
            if (_isSaved)
            {
                File.WriteAllText(_path, MainText);
                FileHasChanges = false;
                return;
            }

            SaveFileDialog saveFolderDialog = new()
            {
                Title = "Сохранение",
                Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true,
                FileName = FileName
            };

            if (saveFolderDialog.ShowDialog() == true)
            {
                _path = saveFolderDialog.FileName;
                _isSaved = true;
                FileName = saveFolderDialog.SafeFileName;
                FileHasChanges = false;

                File.WriteAllText(_path, MainText);
            }
        }
        private void SaveTextMessageBox()
        {
            if (!FileHasChanges) return;
            switch (MessageBox.Show(
                $"Вы хотите сохранить изменения в файле \"{FileName}\"",
                "Сохранить",
                MessageBoxButton.YesNoCancel,
                MessageBoxImage.Question,
                MessageBoxResult.Yes))
            {
                case MessageBoxResult.None:
                    break;
                case MessageBoxResult.OK:
                    break;
                case MessageBoxResult.Cancel:
                    return;
                case MessageBoxResult.Yes:
                    SaveText();
                    break;
                case MessageBoxResult.No:
                    break;
                default:
                    break;
            }
        }
        private void NewFile()
        {
            SaveTextMessageBox();
            _isSaved = false;

            MainText = string.Empty;
        }
        private void OpenFile()
        {
            SaveTextMessageBox();

            OpenFileDialog openFileDialog = new()
            {
                Title = "Открыть",
                Filter = "Text files (*.txt)|*.txt",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _isSaved = true;
                _path = openFileDialog.FileName;
                FileName = openFileDialog.SafeFileName;
                FileHasChanges = false;
                MainText = File.ReadAllText(_path);
            }
        }

        private void MenuItem_ClickNewFile(object sender, RoutedEventArgs e)
        {
            NewFile();
        }
        private void MenuItem_ClickOpenFile(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }
        private void MenuItem_ClickExit(object sender, RoutedEventArgs e)
        {
            SaveTextMessageBox();
            Application.Current.Shutdown(); 
        }
        private void MenuItem_ClickSave(object sender, RoutedEventArgs e)
        {
            SaveText();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            SaveTextMessageBox();
        }

        private void DockPanel_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl))
            {
                if (e.Delta > 0)
                {
                    if (CurrentFontSize < 50) CurrentFontSize++;
                }

                if (e.Delta < 0)
                {
                    if (CurrentFontSize > 1) CurrentFontSize--;
                }
                e.Handled = true;
            }
        }
    }
}