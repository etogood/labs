using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace _4.Notes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public List<Color> BackgroundColors { get; set; }
        public List<FontFamily> FontFamiliesList { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            BackgroundColors =
            [
                new(new(Colors.White), "Белый"),
                new(new(Colors.Yellow), "Жёлтый"),
                new(new(Colors.Pink), "Розовый"),
                new(new(Colors.BlueViolet), "Фиолетовый"),
                new(new(Colors.Red), "Красный"),
                new(new(Colors.Orange), "Оранжевый"),
                new(new(Colors.LightYellow), "Банановый"),
                new(new(Colors.PaleGreen), "Зелёный (классный)")
            ];

            FontFamiliesList = 
            [
                new("Times New Roman"),
                new("Roboto"),
                new("Calibri"),
                new("Arial"),
                new("Consolas")
            ];

            FilePathTB.Text = File.ReadAllText(Directory.GetCurrentDirectory() + @"\path.txt");
        }

        private void Button_ClickSelectPath(object sender, RoutedEventArgs e)
        {
            string dummyFileName = "Save Here";

            OpenFolderDialog sf = new()
            {
                Title = dummyFileName
            };
            sf.ShowDialog();
            FilePathTB.Text = sf.FolderName + @"\notes.txt";
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\path.txt", FilePathTB.Text);
        }

        private void ColorCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            Background = ((Color)ColorCB.SelectedItem).Brush;
        }

        private void FontFamilyCB_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            NoteTextTB.FontFamily = (FontFamily)FontFamilyCB.SelectedItem;
        }

        private void NoteTextTB_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (int.TryParse(FontSizeTB.Text, out int textSize)) NoteTextTB.FontSize = textSize;
            else NoteTextTB.FontSize = 12;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            List<string> strings = [];
            var str = "";
            foreach (var c in NoteTextTB.Text.ToCharArray())
            {
                if (c == '\n' || c == '\r')
                {
                    strings.Add(str);
                    str = "";
                    continue;
                }
                str += c;
            }
            strings.Add(str);
            var res = strings.Where(x => !string.IsNullOrEmpty(x));

            File.WriteAllLines(File.ReadAllText(Directory.GetCurrentDirectory() + @"\path.txt"), res);
        }

        private void Window_Initialized(object sender, EventArgs e)
        {
            try
            {
                NoteTextTB.Text = File.ReadAllText(File.ReadAllText(Directory.GetCurrentDirectory() + @"\path.txt"));
            }
            catch (Exception)
            {
            }
            
        }
    }
}
