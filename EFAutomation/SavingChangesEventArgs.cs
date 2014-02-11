using System;

namespace EFConvention
{
    public class SavingChangesEventArgs : EventArgs
    {
        public IContext Context { get; set; }
    }
}
