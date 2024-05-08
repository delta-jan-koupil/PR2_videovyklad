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

namespace _06_WPF_11_ContactList_MVVM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ContactViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new ContactViewModel();
            this.DataContext = ViewModel;
        }

        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            var newContact = new Contact();
            var addEditContactWindow = new AddEditContactWindow(newContact);
            if (addEditContactWindow.ShowDialog() == true)
            {
                ViewModel.Contacts.Add(newContact);
                DataManager.SaveContacts(ViewModel.Contacts.ToList());
            }
        }

        private void DeleteContactButton_Click(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedContact != null)
            {
                ViewModel.Contacts.Remove(ViewModel.SelectedContact);
                DataManager.SaveContacts(ViewModel.Contacts.ToList());
            }
        }

        private void ContactListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel.SelectedContact != null)
            {
                var addEditContactWindow = new AddEditContactWindow(ViewModel.SelectedContact);
                if (addEditContactWindow.ShowDialog() == true)
                {
                    DataManager.SaveContacts(ViewModel.Contacts.ToList());
                }
            }
        }
    }
}