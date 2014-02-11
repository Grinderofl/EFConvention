using System.Data.Entity.Infrastructure;

namespace EFAutomation.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPostEventListener
    {
        void OnEvent(DbEntityEntry entry);
    }
}