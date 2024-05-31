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
        private SelectedOperator SelectedOperator;

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
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (SelectedOperator)
                {
                    case SelectedOperator.Addition:
                        _result = SimpleMath.Add(_lastNumber, newNumber);
                        break;

                    case SelectedOperator.Subtraction:
                        _result = SimpleMath.Subtraction(_lastNumber, newNumber);
                        break;

                    case SelectedOperator.Multiplication:
                        _result = SimpleMath.Multiply(_lastNumber, newNumber);
                        break;

                    case SelectedOperator.Division:
                        _result = SimpleMath.Divide(_lastNumber, newNumber);
                        break;
                }
                resultLabel.Content = _result.ToString();
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = (tempNumber / 100);
                if (_lastNumber != 0)
                    tempNumber *= _lastNumber;
                resultLabel.Content = tempNumber.ToString();
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
            _result = 0;
            _lastNumber = 0;
        }

        private void OperationButtonClicked(object sender, RoutedEventArgs e)
        {
            Button OperButton = (Button)sender;
            if (double.TryParse(resultLabel.Content.ToString(), out _lastNumber))
            {
                resultLabel.Content = "0";
            }
            if (OperButton == multiplicationButton)
            {
                SelectedOperator = SelectedOperator.Multiplication;
            }
            if (OperButton == divisionButton)
            {
                SelectedOperator = SelectedOperator.Division;
            }
            if (OperButton == plusButton)
            {
                SelectedOperator = SelectedOperator.Addition;
            }
            if (OperButton == minusButton)
            {
                SelectedOperator = SelectedOperator.Subtraction;
            }
        }

        private void pointButton_Click(object sender, RoutedEventArgs e)
        {
            if (!resultLabel.Content.ToString().Contains("."))
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void NumberButtonClicked(object sender, RoutedEventArgs e)
        {
            //create Button class and assign sender as Button by casting
            Button NumButton = (Button)sender;
            //int selectedValue = int.Parse((sender as Button).Content.ToString());

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

    //create enum Operation
    public enum SelectedOperator
    { Addition, Subtraction, Multiplication, Division };

    //create new class SimpleMath
    public class SimpleMath
    {
        public static double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public static double Subtraction(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public static double Divide(double num1, double num2)
        {
            if (num2 == 0)
            {
                MessageBox.Show("Can't divide by 0", "Wrong Operation", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
            return (num1 / num2);
        }
    }
}