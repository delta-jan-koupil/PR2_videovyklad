using System.ComponentModel;

namespace _06_WPF_11_ContactList_MVVM
{
    public class Contact : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private string nickname;
        private string phone;
        private string email;

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged(nameof(FirstName)); }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged(nameof(LastName)); }
        }

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; OnPropertyChanged(nameof(Nickname)); }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; OnPropertyChanged(nameof(Phone)); }
        }

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged(nameof(Email)); }
        }

        public string FullName => $"{FirstName} {LastName}";
    }
}
