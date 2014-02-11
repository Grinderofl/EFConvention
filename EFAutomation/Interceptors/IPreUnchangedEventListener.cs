using System.Data.Entity.Infrastructure;

namespace EFAutomation.Interceptors
{
    /// <summary>
    /// Event listener listens for entities that are unchanged
    /// </summary>
    public interface IPreUnchangedEventListener
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entry"></param>
        void OnUnchanged(DbEntityEntry entry);
    }
}