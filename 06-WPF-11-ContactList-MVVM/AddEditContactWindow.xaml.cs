using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _06_WPF_11_ContactList_MVVM
{
    /// <summary>
    /// Interaction logic for AddEditContactWindow.xaml
    /// </summary>
    public partial class AddEditContactWindow : Window
    {
        public Contact Contact { get; private set; }

        public AddEditContactWindow(Contact contact = null)
        {
            InitializeComponent();
            Contact = contact ?? new Contact();
            this.DataContext = Contact;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
