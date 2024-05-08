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

namespace ContactList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Contact> _contacts;

        public MainWindow()
        {
            InitializeComponent();
            _contacts = DataManager.LoadContacts();
            contactListBox.ItemsSource = _contacts;
        }

        private void ContactListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (contactListBox.SelectedItem != null)
            {
                Contact selectedContact = (Contact)contactListBox.SelectedItem;
                DisplayContactDetails(selectedContact);
            }
        }

        private void DisplayContactDetails(Contact contact)
        {
            nameTextBlock.Text = $"Name: {contact.FullName}";
            nicknameTextBlock.Text = $"Nickname: {contact.Nickname}";
            phoneTextBlock.Text = $"Phone: {contact.Phone}";
            emailTextBlock.Text = $"Email: {contact.Email}";
        }

        private void AddContactButton_Click(object sender, RoutedEventArgs e)
        {
            var addEditContactWindow = new AddEditContactWindow();
            if (addEditContactWindow.ShowDialog() == true)
            {
                var newContact = new Contact
                {
                    FirstName = addEditContactWindow.FirstName,
                    LastName = addEditContactWindow.LastName,
                    Nickname = addEditContactWindow.Nickname,
                    Phone = addEditContactWindow.Phone,
                    Email = addEditContactWindow.Email
                };

                _contacts.Add(newContact);
                RefreshContactList();

                DataManager.SaveContacts(_contacts);
            }
        }

        private void EditContactButton_Click(object sender, RoutedEventArgs e)
        {
            if (contactListBox.SelectedItem != null)
            {
                var selectedContact = (Contact)contactListBox.SelectedItem;
                var addEditContactWindow = new AddEditContactWindow(selectedContact);
                if (addEditContactWindow.ShowDialog() == true)
                {
                    selectedContact.FirstName = addEditContactWindow.FirstName;
                    selectedContact.LastName = addEditContactWindow.LastName;
                    selectedContact.Nickname = addEditContactWindow.Nickname;
                    selectedContact.Phone = addEditContactWindow.Phone;
                    selectedContact.Email = addEditContactWindow.Email;

                    RefreshContactList();

                    DataManager.SaveContacts(_contacts);
                }
            }
        }

        private void ContactListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox != null && listBox.SelectedItem != null)
            {
                var selectedContact = (Contact)listBox.SelectedItem;
                var addEditContactWindow = new AddEditContactWindow(selectedContact);               
                if (addEditContactWindow.ShowDialog() == true)
                {
                    selectedContact.FirstName = addEditContactWindow.FirstName;
                    selectedContact.LastName = addEditContactWindow.LastName;
                    selectedContact.Nickname = addEditContactWindow.Nickname;
                    selectedContact.Phone = addEditContactWindow.Phone;
                    selectedContact.Email = addEditContactWindow.Email;

                    DataManager.SaveContacts(_contacts);

                    RefreshContactList();
                }
            }
        }

        private void DeleteContactButton_Click(object sender, RoutedEventArgs e)
        {
            if (contactListBox.SelectedItem != null)
            {
                var selectedContact = (Contact)contactListBox.SelectedItem;
                var result = MessageBox.Show("Are you sure you want to delete this contact?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    _contacts.Remove(selectedContact);
                    RefreshContactList();

                    DataManager.SaveContacts(_contacts);
                }
            }
        }

        private void RefreshContactList()
        {
            contactListBox.ItemsSource = null;
            contactListBox.ItemsSource = _contacts;
        }
    }
}