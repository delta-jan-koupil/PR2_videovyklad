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

namespace _06_WPF_01_Hello_world
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isHelloWorld;

        public MainWindow()
        {
            InitializeComponent();
            _isHelloWorld = true;
            MyLabel.Content = "Hello world!";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (_isHelloWorld)
                MyLabel.Content = "Goodbye world!";
            else
                MyLabel.Content = "Hello world!";

            _isHelloWorld = !_isHelloWorld;
        }
    }
}