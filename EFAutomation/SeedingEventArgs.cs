using System;

namespace EFConvention
{
    public class SeedingEventArgs : EventArgs
    {
        public IContext Context { get; set; }
    }
}
