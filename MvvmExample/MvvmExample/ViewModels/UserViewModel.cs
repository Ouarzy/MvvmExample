using MvvmExample.Models;

namespace MvvmExample.ViewModels
{
    public class UserViewModel
    {
        public string LastName { get; set; }

        public string FirstName { get; set; }

        public UserViewModel(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
        }
    }
}