using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutomation
{
    public class SavingChangesEventArgs : EventArgs
    {
        public IContext Context { get; set; }
    }
}
