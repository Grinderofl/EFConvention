using System.Data.Entity.Infrastructure;

namespace EFConventions.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPostDeleteEventListener
    {
        void OnDelete(DbEntityEntry entry);
    }
}
