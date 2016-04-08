using System.Collections.Generic;
using System.Windows.Threading;
using MvvmExample.Models;

namespace MvvmExample.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private IPageViewModel _currentViewModel;

        public IPageViewModel CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }

            private set
            {
                _currentViewModel = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewModel(Dispatcher uiDispatcher)
            : base(uiDispatcher)
        {
            CurrentViewModel = new ChartViewModel(
                                   GenerateProducts(),
                                   GenerateUser(), 
                                   uiDispatcher);
        }

        private static User GenerateUser()
        {
            var user = new User("Ouarzy", "Warzy");
            
            //comment one of the above to simulate an invalid user for the BuyingService
            user.ChangeAdress(new Adress("3 route de tartampion", "6900", "Lyon", "France"));
            user.Authenticate("UserLogin", "UserPassword");
            
            return user;
        }

        private static List<Product> GenerateProducts()
        {
            return new List<Product>
                   {
                       new Product("1", "Video Game"),
                       new Product("2", "Book"),
                       new Product("3", "BluRay")
                   };
        }
    }
}
