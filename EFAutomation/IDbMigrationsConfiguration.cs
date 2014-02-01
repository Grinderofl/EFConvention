using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Design;
using System.Data.Entity.Migrations.History;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EFAutomation
{
    public interface IDbMigrationsConfiguration
    {
        event SeedingEventHandler Seeding;
        bool AutomaticMigrationDataLossAllowed { get; set; }
        bool AutomaticMigrationsEnabled { get; set; }
        MigrationCodeGenerator CodeGenerator { get; set; }
        int? CommandTimeout { get; set; }
        string ContextKey { get; set; }
        Type ContextType { get; set; }
        Assembly MigrationsAssembly { get; set; }
        string MigrationsDirectory { get; set; }
        string MigrationsNamespace { get; set; }
        DbConnectionInfo TargetDatabase { get; set; }
        MigrationSqlGenerator GetSqlGenerator(string providerName);
        Func<DbConnection, string, HistoryContext> GetHistoryContextFactory(string providerInvariantName);
        void SetHistoryContextFactory(string providerInvariantName, Func<DbConnection, string, HistoryContext> factory);
        void SetSqlGenerator(string providerInvariantName, MigrationSqlGenerator migrationSqlGenerator);
    }

    public delegate void SeedingEventHandler(object sender, IContext context);
}
