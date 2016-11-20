namespace ErieGarbageOnline.Models
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Authorized { get; set; }
        public AccountType Type
        {
            get { return _type; }
            // account type is immutable, just in case
            set { if (_type == AccountType.Null) _type = value; }
        }

        private AccountType _type = AccountType.Null;
    }

    public enum AccountType
    {
        Customer,
        Admin,
        Null
    }
}