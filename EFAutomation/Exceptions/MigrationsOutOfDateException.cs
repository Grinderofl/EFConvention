using System;

namespace EFConventions.Exceptions
{
    public class MigrationsOutOfDateException : Exception
    {
        public MigrationsOutOfDateException(string message, Exception exception) : base(message, exception)
        {
            
        }
    }
}
