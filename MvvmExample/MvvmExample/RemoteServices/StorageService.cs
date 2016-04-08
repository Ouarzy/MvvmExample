using MvvmExample.Models;

namespace MvvmExample.RemoteServices
{
    /// <summary>
    /// Simulate a potential remote service to call to know if a product is currently available in store
    /// </summary>
    public class StorageService
    {
        public bool IsAvailable(Product product)
        {
            //change to false to simulate an unavailable product
            return false;
        }
    }
}
