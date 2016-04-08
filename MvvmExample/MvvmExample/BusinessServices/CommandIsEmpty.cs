using System;

namespace MvvmExample.BusinessServices
{
    public class CommandIsEmpty : Exception
    {
        public CommandIsEmpty(string message)
            : base(message)
        {
        }
    }
}