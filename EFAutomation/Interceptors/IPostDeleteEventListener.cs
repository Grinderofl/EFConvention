using System.Data.Entity.Infrastructure;

namespace EFConvention.Interceptors
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPostDeleteEventListener
    {
        void OnDelete(DbEntityEntry entry);
    }
}