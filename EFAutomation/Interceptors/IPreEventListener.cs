using System.Data.Entity.Infrastructure;

namespace EFConventions.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPreEventListener
    {
        void OnEvent(DbEntityEntry entry);
    }
}