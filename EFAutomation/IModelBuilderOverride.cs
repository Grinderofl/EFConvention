using System.Data.Entity.ModelConfiguration;

namespace EFConvention
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IModelBuilderOverride<T> where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        void Configure(EntityTypeConfiguration<T> entity);
    }

}
