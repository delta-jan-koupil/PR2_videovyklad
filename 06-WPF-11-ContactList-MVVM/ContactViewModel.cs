using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace _06_WPF_11_ContactList_MVVM
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Contact> Contacts { get; set; }
        private Contact selectedContact;

        public Contact SelectedContact
        {
            get { return selectedContact; }
            set { selectedContact = value; OnPropertyChanged(nameof(SelectedContact)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ContactViewModel()
        {
            Contacts = new ObservableCollection<Contact>(DataManager.LoadContacts());
        }
    }
}
