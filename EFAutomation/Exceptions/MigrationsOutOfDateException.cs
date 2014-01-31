using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutomation.Exceptions
{
    public class MigrationsOutOfDateException : Exception
    {
        public MigrationsOutOfDateException(string message, Exception exception) : base(message, exception)
        {
            
        }
    }
}
