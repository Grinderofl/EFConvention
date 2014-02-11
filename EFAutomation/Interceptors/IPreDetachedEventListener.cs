using System.Data.Entity.Infrastructure;

namespace EFAutomation.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPreDetachedEventListener
    {
        void OnDetach(DbEntityEntry entry);
    }
}