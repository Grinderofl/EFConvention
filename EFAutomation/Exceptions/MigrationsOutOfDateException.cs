using System;

namespace EFConvention.Exceptions
{
    public class MigrationsOutOfDateException : Exception
    {
        public MigrationsOutOfDateException(string message, Exception exception) : base(message, exception)
        {
            
        }
    }
}
