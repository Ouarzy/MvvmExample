namespace MvvmExample.Models
{
    public class User
    {
        private Adress _adress;

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public bool IsAuthenticated { get; private set; }

        public bool HasValidAdress
        {
            get
            {
                return _adress != null;
            }
        }

        public User(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public void ChangeAdress(Adress adress)
        {
            _adress = adress;
        }

        public void Authenticate(string userLogin, string userPassword)
        {
            IsAuthenticated = true;
        }
    }
}