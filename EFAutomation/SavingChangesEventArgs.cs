using System;

namespace EFConventions
{
    public class SavingChangesEventArgs : EventArgs
    {
        public IContext Context { get; set; }
    }
}
