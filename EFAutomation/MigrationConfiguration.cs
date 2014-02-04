using System.Data.Entity.Migrations;

namespace EFAutomation
{
    /// <summary>
    /// Migrations
    /// </summary>
    internal class MigrationConfiguration : DbMigrationsConfiguration<Context>
    {
        /// <summary>
        /// Seeding
        /// </summary>
        public SeedingEventHandler Seeding;
        
        protected override void Seed(Context context)
        {
            if (Seeding != null)
                Seeding(this, new SeedingEventArgs() {Context = context});
            base.Seed(context);
        }
    }
}