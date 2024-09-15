using System.Collections.ObjectModel;
using System.Windows;

namespace _3.CalculatorPlus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isRightSide = false;

        bool isPlus = false;
        bool isMinus = false;
        bool isMultiply = false;
        bool isDivide = false;

        public ObservableCollection<CalculatorHistory> HistoryList { get; set; }

        float Result
        {
            get
            {
                if (float.TryParse(leftPart, out float left) && float.TryParse(rightPart, out float right))
                {
                    if (isPlus) return left + right;
                    if (isMinus) return left - right;
                    if (isMultiply) return left * right;
                    if (isDivide) return left / right;
                }

                return 0;
            }
        }
        string leftPart = "";
        string rightPart = "";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            HistoryList  = [];
        }
        private void Button_Click0(object sender, RoutedEventArgs e)
        {
            ViewFieldTB.Text += "0";
            if (isRightSide) rightPart += "0";
            else leftPart += "0";
        }
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            ViewFieldTB.Text += "1";
            if (isRightSide) rightPart += "1";
            else leftPart += "1";
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            ViewFieldTB.Text += "2";
            if (isRightSide) rightPart += "2";
            else leftPart += "2";
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            ViewFieldTB.Text += "3";
            if (isRightSide) rightPart += "3";
            else leftPart += "3";
        }
        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            ViewFieldTB.Text += "4";
            if (isRightSide) rightPart += "4";
            else leftPart += "4";
        }
        private void Button_Click5(object sender, RoutedEventArgs e)
        {
            ViewFieldTB.Text += "5";
            if (isRightSide) rightPart += "5";
            else leftPart += "5";
        }
        private void Button_Click6(object sender, RoutedEventArgs e)
        {
            ViewFieldTB.Text += "6";
            if (isRightSide) rightPart += "6";
            else leftPart += "6";
        }
        private void Button_Click7(object sender, RoutedEventArgs e)
        {
            ViewFieldTB.Text += "7";
            if (isRightSide) rightPart += "7";
            else leftPart += "7";
        }
        private void Button_Click8(object sender, RoutedEventArgs e)
        {
            ViewFieldTB.Text += "8";
            if (isRightSide) rightPart += "8";
            else leftPart += "8";
        }
        private void Button_Click9(object sender, RoutedEventArgs e)
        {
            ViewFieldTB.Text += "9";
            if (isRightSide) rightPart += "9";
            else leftPart += "9";
        }
        private void Button_ClickPlus(object sender, RoutedEventArgs e)
        {
            if (!isRightSide)
            {
                isRightSide = true;
                leftPart = ViewFieldTB.Text;
            }
            else
            {
                leftPart = Result.ToString();
                rightPart = "";
            }
            ViewFieldTB.Text += "+";

            isPlus = true;
            isMinus = false;
            isMultiply = false;
            isDivide = false;

            SetButtonsInactive();
        }
        private void Button_ClickMinus(object sender, RoutedEventArgs e)
        {
            if (!isRightSide)
            {
                isRightSide = true;
                leftPart = ViewFieldTB.Text;
            }
            else
            {
                leftPart = Result.ToString();
                rightPart = "";
            }
            ViewFieldTB.Text += "-";

            isPlus = false;
            isMinus = true;
            isMultiply = false;
            isDivide = false;

            SetButtonsInactive();
        }
        private void Button_ClickMultiply(object sender, RoutedEventArgs e)
        {
            if (!isRightSide)
            {
                isRightSide = true;
                leftPart = ViewFieldTB.Text;
            }
            else
            {
                leftPart = Result.ToString();
                rightPart = "";
            }
            ViewFieldTB.Text += "*";

            isPlus = false;
            isMinus = false;
            isMultiply = true;
            isDivide = false;

            SetButtonsInactive();
        }
        private void Button_ClickDivide(object sender, RoutedEventArgs e)
        {
            if (!isRightSide)
            {
                isRightSide = true;
                leftPart = ViewFieldTB.Text;
            }
            else
            {
                leftPart = Result.ToString();
                rightPart = "";
            }
            ViewFieldTB.Text += "/";

            isPlus = false;
            isMinus = false;
            isMultiply = false;
            isDivide = true;

            SetButtonsInactive();
        }
        private void Button_ClickEqual(object sender, RoutedEventArgs e)
        {

            if (SaveHistoryCBToHide.IsChecked.Value) AddToHistory();

            ViewFieldTB.Text = Result.ToString();
            leftPart = Result.ToString();
            rightPart = "";
            isRightSide = false;

            SetButtonsActive();

            isPlus = false;
            isMinus = false;
            isMultiply = false;
            isDivide = false;
        }
        private void Button_ClickClear(object sender, RoutedEventArgs e)
        {
            ViewFieldTB.Text = "";
            leftPart = "";
            rightPart = "";
            isRightSide = false;

            isPlus = false;
            isMinus = false;
            isMultiply = false;
            isDivide = false;

            SetButtonsActive();
        }

        private void SetButtonsInactive()
        {
            PlusButton.IsEnabled = false;
            MinusButton.IsEnabled = false;
            MultiplyButton.IsEnabled = false;
            DivideButton.IsEnabled = false;
        }

        private void SetButtonsActive()
        {
            PlusButton.IsEnabled = true;
            MinusButton.IsEnabled = true;
            MultiplyButton.IsEnabled = true;
            DivideButton.IsEnabled = true;
        }

        private void AddToHistory()
        {
            if (isPlus) HistoryList.Add(new CalculatorHistory { Equasion = $"{leftPart} + {rightPart} = {Result}" });
            if (isMinus) HistoryList.Add(new CalculatorHistory { Equasion = $"{leftPart} - {rightPart} = {Result}" });
            if (isMultiply) HistoryList.Add(new CalculatorHistory { Equasion = $"{leftPart} * {rightPart} = {Result}" });
            if (isDivide) HistoryList.Add(new CalculatorHistory { Equasion = $"{leftPart} / {rightPart} = {Result}" });
        }

        private void Button_ClickClearHistory(object sender, RoutedEventArgs e)
        {
            HistoryList.Clear();
        }

        private void Button_ClickRemoveLastItem(object sender, RoutedEventArgs e)
        {
            if (HistoryList.Count == 0) return;
            HistoryList.RemoveAt(HistoryList.Count - 1);
        }

        private void RadioButton_CheckedHide(object sender, RoutedEventArgs e)
        {
            HistoryToHide.Visibility = Visibility.Hidden;
            SaveHistoryCBToHide.Visibility = Visibility.Hidden;
            CBTextToHide.Visibility = Visibility.Hidden;
            
            Column1.Width = new GridLength(300);
            Column2.Width = new GridLength(0);
            Width = 350;
        }

        private void RadioButton_CheckedShow(object sender, RoutedEventArgs e)
        {
            HistoryToHide.Visibility = Visibility.Visible;
            SaveHistoryCBToHide.Visibility = Visibility.Visible;
            CBTextToHide.Visibility = Visibility.Visible;

            Column1.Width = new GridLength(300);
            Column2.Width = new GridLength(300);
            Width = 640;

        }
    }
}