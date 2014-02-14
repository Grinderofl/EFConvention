using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EFConvention
{
    /// <summary>
    /// Performs seeding functions on a specific entity from the context.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntitySeed<T> where T : class
    {
        /// <summary>
        /// Seed the entity
        /// </summary>
        /// <param name="entity"></param>
        void Seed(DbSet<T> entity);
    }
}
