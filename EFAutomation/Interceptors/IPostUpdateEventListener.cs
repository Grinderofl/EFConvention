using System.Data.Entity.Infrastructure;

namespace EFConvention.Interceptors
{
    /// <summary>
    /// Listener for update events
    /// </summary>
    public interface IPostUpdateEventListener
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityEntry"></param>
        void OnUpdate(DbEntityEntry entityEntry);
    }
}
