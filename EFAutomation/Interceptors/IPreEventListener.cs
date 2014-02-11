using System.Data.Entity.Infrastructure;

namespace EFAutomation.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPreEventListener
    {
        void OnEvent(DbEntityEntry entry);
    }
}