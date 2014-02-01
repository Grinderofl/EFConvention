using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutomation
{
    public class SeedingEventArgs : EventArgs
    {
        public IContext Context { get; set; }
    }
}
