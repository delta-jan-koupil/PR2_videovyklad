using CsvHelper;
using System.Globalization;
using System.IO;

namespace _06_WPF_11_ContactList_MVVM
{
    public static class DataManager
    {
        private static readonly string FilePath = "contacts.csv";

        public static List<Contact> LoadContacts()
        {
            List<Contact> contacts = new List<Contact>();

            if (File.Exists(FilePath))
            {
                using (var reader = new StreamReader(FilePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    contacts = csv.GetRecords<Contact>().ToList();
                }
            }

            return contacts;
        }

        public static void SaveContacts(List<Contact> contacts)
        {
            using (var writer = new StreamWriter(FilePath))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(contacts);
            }
        }
    }
}
