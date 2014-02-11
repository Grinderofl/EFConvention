using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutomation.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPreDeleteEventListener
    {
        void OnDelete(DbEntityEntry entry);
    }
}
