using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutomation
{
    public class ValidatingEntityEventArgs : EventArgs
    {
        public DbEntityEntry EntityEntry { get; set; }
        public IDictionary<object, object> Items { get; set; }
    }
}
