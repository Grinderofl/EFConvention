using System.Data.Entity.Infrastructure;

namespace EFConvention.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPostEventListener
    {
        void OnEvent(DbEntityEntry entry);
    }
}