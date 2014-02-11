using System;

namespace EFConventions
{
    public class SeedingEventArgs : EventArgs
    {
        public IContext Context { get; set; }
    }
}
