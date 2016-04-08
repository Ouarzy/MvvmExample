using MvvmExample.Models;

namespace MvvmExample.RemoteServices
{
    /// <summary>
    /// External service with the responsibility to actually send the command to the customer
    /// </summary>
    public class ShippingService
    {
        public void Send(ChartCommand chartCommand)
        {
            //no implementation here as we simulate a remote call
        }
    }
}
