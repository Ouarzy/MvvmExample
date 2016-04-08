using System;

namespace MvvmExample.BusinessServices
{
    public class UserShouldBeAuthenticatedException : Exception
    {
        public UserShouldBeAuthenticatedException(string message)
            : base(message)
        {
        }
    }
}