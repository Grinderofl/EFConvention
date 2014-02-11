using System.Data.Entity.Infrastructure;

namespace EFConvention.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPreDetachedEventListener
    {
        void OnDetach(DbEntityEntry entry);
    }
}