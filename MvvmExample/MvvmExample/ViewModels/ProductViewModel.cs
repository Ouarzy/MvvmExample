using MvvmExample.Models;

namespace MvvmExample.ViewModels
{
    public class ProductViewModel
    {
        public string Description { get; private set; }

        public string Id { get; private set; }

        public ProductViewModel(Product product)
        {
            Id = product.Id;
            Description = product.Description;
        }
    }
}