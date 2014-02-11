using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;

namespace EFConvention
{
    public class ValidatingEntityEventArgs : EventArgs
    {
        public DbEntityEntry EntityEntry { get; set; }
        public IDictionary<object, object> Items { get; set; }
    }
}
