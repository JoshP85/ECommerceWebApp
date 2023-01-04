namespace ECommerceWebApp.Models
{
    public class RegisteredUser
    {
        public RegisteredUser()
        {
            _registeredUserId = new Guid().ToString();
        }
        public enum UserType
        {
            Customer,
            Employee,
            Admin
        }

        private UserType _type;
        private string _registeredUserId;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private string _phone;
        private string _address;

        public UserType Type { get { return _type; } set { _type = value; } }
        public string RegisteredUserId { get { return _registeredUserId; } }
        public string FirstName { get { return _firstName; } set { _firstName = value; } }
        public string LastName { get { return _lastName; } set { _lastName = value; } }
        public string Email { get { return _email; } set { _email = value; } }
        public string Password { get { return _password; } set { _password = value; } }
        public string Phone { get { return _phone; } set { _phone = value; } }
        public string Address { get { return _address; } set { _address = value; } }

    }
}
