using System;

namespace MvvmExample.BusinessServices
{
    public class UserShouldHaveAValidAdress : Exception
    {
        public UserShouldHaveAValidAdress(string message)
            : base(message)
        {
        }
    }
}