using System.Data.Entity.Infrastructure;

namespace EFConvention.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPreEventListener
    {
        void OnEvent(DbEntityEntry entry);
    }
}