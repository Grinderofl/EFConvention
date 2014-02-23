using System;
using System.Data.Entity;

namespace EFConvention
{
    public class SeedingEventArgs : EventArgs
    {
        public DbContext Context { get; set; }
    }
}
