using System.Data.Entity.Infrastructure;

namespace EFAutomation.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPostDetachedEventListener
    {
        void OnDetach(DbEntityEntry entry);
    }
}