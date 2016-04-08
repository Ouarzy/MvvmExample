using System.Collections.Generic;
using System.Linq;
using MvvmExample.Models;
using MvvmExample.RemoteServices;

namespace MvvmExample.BusinessServices
{
    /// <summary>
    /// A business service to validate a chart for a user
    /// </summary>
    public class BuyingService
    {
        private readonly StorageService _storageService = new StorageService();
        private readonly ShippingService _shippingService = new ShippingService();

        public void Validate(IList<Product> proudctsInChart, User user)
        {
            if (!proudctsInChart.Any())
            {
                throw new CommandIsEmpty("A command should contain some products");                
            }

            if (!user.IsAuthenticated)
            {
                throw new UserShouldBeAuthenticatedException("User should be authenticated to buy a product");
            }

            if (!user.HasValidAdress)
            {
                throw new UserShouldHaveAValidAdress("User should have a valid adress to buy a product");
            }

            foreach (var product in proudctsInChart)
            {
                if (!_storageService.IsAvailable(product))
                {
                    throw new ProductIsUnavailable("The product " + product.Description + " is not available in the store right now");    
                }
            }

            _shippingService.Send(new ChartCommand(proudctsInChart, user));
        }
    }
}
