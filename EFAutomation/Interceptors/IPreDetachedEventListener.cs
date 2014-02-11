using System.Data.Entity.Infrastructure;

namespace EFConventions.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPreDetachedEventListener
    {
        void OnDetach(DbEntityEntry entry);
    }
}