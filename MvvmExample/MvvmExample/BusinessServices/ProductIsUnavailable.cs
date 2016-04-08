using System;

namespace MvvmExample.BusinessServices
{
    public class ProductIsUnavailable : Exception
    {
        public ProductIsUnavailable(string message) 
            : base(message)
        {
        }
    }
}