using System.Data.Entity.Infrastructure;

namespace EFConventions.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPostEventListener
    {
        void OnEvent(DbEntityEntry entry);
    }
}