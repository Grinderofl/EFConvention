using System;
using System.Data.Entity;

namespace EFConvention
{
    public class SavingChangesEventArgs : EventArgs
    {
        public DbContext Context { get; set; }
    }
}
