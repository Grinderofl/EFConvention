
using System.Data.Entity.Infrastructure;

namespace EFConventions.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPreDeleteEventListener
    {
        void OnDelete(DbEntityEntry entry);
    }
}
