using System.Data.Entity.Infrastructure;

<<<<<<< HEAD
namespace EFConventions.Interceptors
=======
namespace EFAutomation.Interceptors
>>>>>>> cf4659b760e07050a0426662dd0cba0acde539aa
{
    /// <summary>
    /// Event listener listens for entities that are unchanged
    /// </summary>
    public interface IPostUnchangedEventListener
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entry"></param>
        void OnUnchanged(DbEntityEntry entry);
    }
}