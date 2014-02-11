using System.Data.Entity.Infrastructure;

namespace EFConvention.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPostDetachedEventListener
    {
        void OnDetach(DbEntityEntry entry);
    }
}