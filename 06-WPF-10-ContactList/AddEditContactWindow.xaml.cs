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

namespace ContactList
{
    /// <summary>
    /// Interaction logic for AddEditContactWindow.xaml
    /// </summary>
    public partial class AddEditContactWindow : Window
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Nickname { get; private set; }
        public string Phone { get; private set; }
        public string Email { get; private set; }

        public AddEditContactWindow(Contact contact = null)
        {
            InitializeComponent();

            if (contact != null)
            {
                firstNameTextBox.Text = contact.FirstName;
                lastNameTextBox.Text = contact.LastName;
                nicknameTextBox.Text = contact.Nickname;
                phoneTextBox.Text = contact.Phone;
                emailTextBox.Text = contact.Email;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            FirstName = firstNameTextBox.Text;
            LastName = lastNameTextBox.Text;
            Nickname = nicknameTextBox.Text;
            Phone = phoneTextBox.Text;
            Email = emailTextBox.Text;

            DialogResult = true;
        }
    }
}
