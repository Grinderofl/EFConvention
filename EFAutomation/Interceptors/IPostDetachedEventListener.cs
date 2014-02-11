using System.Data.Entity.Infrastructure;

namespace EFConventions.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPostDetachedEventListener
    {
        void OnDetach(DbEntityEntry entry);
    }
}