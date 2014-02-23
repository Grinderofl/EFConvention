using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace EFConvention
{
    /// <summary>
    /// Migrations
    /// </summary>
    internal class MigrationConfiguration : DbMigrationsConfiguration<DbContext>
    {
        /// <summary>
        /// Seeding
        /// </summary>
        public SeedingEventHandler Seeding;
        
        protected override void Seed(DbContext context)
        {
            if (Seeding != null)
                Seeding(this, new SeedingEventArgs() {Context = context});
            base.Seed(context);
        }
    }
}