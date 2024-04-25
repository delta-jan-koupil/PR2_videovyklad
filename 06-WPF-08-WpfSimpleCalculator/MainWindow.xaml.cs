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

namespace WpfSimpleCalculator
{
    enum Operation { Addition, Subtraction, Multiplication, Divison }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _lastNumber;

        //private string _currentNumber;
        //public string CurrentNumber
        //{
        //    get { return _currentNumber; }
        //    set { 
        //        _currentNumber = value;
        //        DisplayTB.Text = value;
        //    }
        //}


        public string CurrentNumber
        {
            get { return (string)GetValue(CurrentNumberProperty); }
            set { SetValue(CurrentNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentNumberProperty =
            DependencyProperty.Register("CurrentNumber", typeof(string), typeof(MainWindow), new PropertyMetadata(""));


        private Operation _operation;

        public MainWindow()
        {
            InitializeComponent();
            CurrentNumber = "0";
        }

        private void NumberBtn_Click(object sender, RoutedEventArgs e)
        {
            string digit = ((Button)sender).Content.ToString();

            if (CurrentNumber == "0")
                CurrentNumber = digit;

            else
                CurrentNumber += digit;
        }

        private void ACBtn_Click(object sender, RoutedEventArgs e)
        {
            CurrentNumber = "0";
        }

        private void PlusMinusBtn_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse(CurrentNumber);
            number *= -1;
            CurrentNumber = number.ToString();
        }

        private void PercentBtn_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse(CurrentNumber);
            number = SimpleMath.Percent(number);
            CurrentNumber = number.ToString();
        }

        private void DotBtn_Click(object sender, RoutedEventArgs e)
        {
            string decimalSign = System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;

            if (!CurrentNumber.Contains(decimalSign))
                CurrentNumber += decimalSign;
        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            _lastNumber = double.Parse(CurrentNumber);
            CurrentNumber = "0";

            if (sender == PlusBtn)
                _operation = Operation.Addition;
            else if (sender == MinusBtn)
                _operation = Operation.Subtraction;
            else if (sender == MultiplyBtn)
                _operation = Operation.Multiplication;
            else if (sender == DivideBtn)
                _operation = Operation.Divison;            
        }

        private void CalculateBtn_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse(CurrentNumber);

            double result = _operation switch
            {
                Operation.Addition => SimpleMath.Add(_lastNumber, number),
                Operation.Subtraction => SimpleMath.Subtract(_lastNumber, number),
                Operation.Multiplication => SimpleMath.Multiply(_lastNumber, number),
                Operation.Divison => SimpleMath.Divide(_lastNumber, number),
                _ => 0
            };

            CurrentNumber = result.ToString();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Add:
                    //OperationBtn_Click(PlusBtn, null);
                    PlusBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                    //...

                case Key.NumPad0:
                    ZeroBtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    break;

                    //...
            }
        }
    }
}