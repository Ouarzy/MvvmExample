using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using System.Windows.Threading;
using MvvmExample.BusinessServices;
using MvvmExample.Models;

namespace MvvmExample.ViewModels
{
    public class ChartViewModel : ViewModelBase, IPageViewModel
    {
        private readonly IEnumerable<Product> _availableProducts;
        private readonly User _user;
        private readonly BuyingService _buyingService = new BuyingService();
        private string _messageInfo;
        private bool _messageInfoIsVisible;

        public string MessageInfo
        {
            get
            {
                return _messageInfo;
            }

            set
            {
                _messageInfo = value;
                NotifyPropertyChanged();
            }
        }

        public bool MessageInfoIsVisible
        {
            get
            {
                return _messageInfoIsVisible;
            }

            set
            {
                _messageInfoIsVisible = value;
                NotifyPropertyChanged();
            }
        }

        public IEnumerable<ProductViewModel> ProductsAvailable { get; private set; }

        public ProductViewModel SelectedProduct { get; set; }

        public ObservableCollection<ProductViewModel> ProductsInChart { get; private set; }

        public UserViewModel User { get; private set; }

        public ICommand AddToChart { get; private set; }

        public ICommand Buy { get; private set; }

        public ICommand DismissMessageInfo { get; private set; }

        public ChartViewModel(IList<Product> availableProducts, User user, Dispatcher uiDispatcher)
            : base(uiDispatcher)
        {
            _availableProducts = availableProducts;
            _user = user;
            ProductsAvailable = new List<ProductViewModel>(availableProducts.Select(p => new ProductViewModel(p)));
            ProductsInChart = new ObservableCollection<ProductViewModel>();
            User = new UserViewModel(user);
            AddToChart = new RelayCommand(OnAddToChart);
            Buy = new RelayCommand(OnBuy);
            DismissMessageInfo = new RelayCommand(OnDismissMessageInfo);
        }

        private void OnAddToChart()
        {
            if (SelectedProduct != null)
            {
                ProductsInChart.Add(SelectedProduct);
            }
        }

        private void OnBuy()
        {
            try
            {
                _buyingService.Validate(_availableProducts.Where(p => ProductsInChart.Select(pvm => pvm.Id).Contains(p.Id)).ToList(), _user);
                DisplayMessage("Your command is validated");
            }
            catch (Exception ex)
            {
                DisplayMessage("Your command cannot be validated: " + ex.Message);
            }
        }

        private void OnDismissMessageInfo()
        {
            MessageInfoIsVisible = false;
            MessageInfo = string.Empty;
        }

        private void DisplayMessage(string message)
        {
            MessageInfoIsVisible = true;
            MessageInfo = message;
        }
    }
}
