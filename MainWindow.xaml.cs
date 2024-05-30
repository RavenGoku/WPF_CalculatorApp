using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_CalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _lastNumber, _result;

        public MainWindow()
        {
            InitializeComponent();
            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalButton.Click += EqualButton_Click;
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
        {
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out _lastNumber))
            {
                _lastNumber = _lastNumber / 100;
                resultLabel.Content = _lastNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out _lastNumber))
            {
                _lastNumber = _lastNumber * -1;
                resultLabel.Content = _lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void OperationButtonClicked(object sender, RoutedEventArgs e)
        {
            Button OperButton = (Button)sender;
        }

        private void NumberButtonClicked(object sender, RoutedEventArgs e)
        {
            //create Button class and assign sender as Button by casting
            Button NumButton = (Button)sender;

            if (resultLabel.Content.ToString() == "0")
            {
                //use button object.content and assign to label content
                resultLabel.Content = $"{NumButton.Content}";
            }
            else
            {
                //use button object.content and assign to label content and concatination with content already in label
                resultLabel.Content = $"{resultLabel.Content}{NumButton.Content}";
            }
        }
    }
}