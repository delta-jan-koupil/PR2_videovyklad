namespace ContactList
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
