using System.Data.Entity.Infrastructure;

namespace EFConventions.Interceptors
{
    /// <summary>
    /// Listener for update events
    /// </summary>
    public interface IPreUpdateEventListener
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entityEntry"></param>
        void OnUpdate(DbEntityEntry entityEntry);
    }
}
