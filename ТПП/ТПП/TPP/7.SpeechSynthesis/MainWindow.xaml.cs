using System.Windows;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media;

namespace _7.SpeechSynthesis
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly private SpeechSynthesizer _synthesizer = new();
        readonly private PromptBuilder _prompt = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            _prompt.ClearContent();

            var matches = txtSpeech.Text.Split(' ');
            // Я <esl>хочу</esl> <f>сказать</f> что-то <a>очень</a> важное
            foreach (var item in matches)
            {
                if (Tag().IsMatch(item))
                {
                    var text = item.Substring(item.IndexOf('>') + 1, item.IndexOf("</") - item[..item.IndexOf('>')].Length - 1);
                    var tag = item.Substring(item.IndexOf('<') + 1, item[..item.IndexOf('>')].Length - 1); // Нельзя оборачивать в несколько тэгов

                    switch (tag)
                    {
                        case "na":
                            _prompt.AppendText(text, PromptEmphasis.Reduced);
                            break;
                        case "a":
                            _prompt.AppendText(text, PromptEmphasis.Strong);
                            break;

                        case "esl":
                            _prompt.AppendText(text, PromptRate.ExtraSlow);
                            break;
                        case "sl":
                            _prompt.AppendText(text, PromptRate.Slow);
                            break;
                        case "f":
                            _prompt.AppendText(text, PromptRate.Fast);
                            break;
                        case "ef":
                            _prompt.AppendText(text, PromptRate.ExtraFast);
                            break;

                        case "sil":
                            _prompt.AppendText(text, PromptVolume.Silent);
                            break;
                        case "es":
                            _prompt.AppendText(text, PromptVolume.ExtraSoft);
                            break;
                        case "s":
                            _prompt.AppendText(text, PromptVolume.Soft);
                            break;
                        case "l":
                            _prompt.AppendText(text, PromptVolume.Loud);
                            break;
                        case "el":
                            _prompt.AppendText(text, PromptVolume.ExtraLoud);
                            break;

                        default: 
                            break;
                    }
                    continue;
                }
                _prompt.AppendText(item);
            }


            _synthesizer.Speak(_prompt);
        }

        [GeneratedRegex(@"<(\w+)>.*?<\/\1>")]
        private static new partial Regex Tag();

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Title = "Сохранить",
                Filter = "Text file (*.txt)|*.txt"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, txtSpeech.Text);
                MessageBox.Show($"Файл сохранен по пути {saveFileDialog.FileName}");
            }
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Title = "Выберите текст",
                Filter = "Text file (*.txt)|*.txt"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                txtSpeech.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }
    }
}