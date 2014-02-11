
using System.Data.Entity.Infrastructure;

namespace EFConvention.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPreDeleteEventListener
    {
        void OnDelete(DbEntityEntry entry);
    }
}
