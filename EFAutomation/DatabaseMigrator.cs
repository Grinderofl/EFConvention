using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp;

namespace EFAutomation
{
    public class DatabaseMigrator
    {
        private DbMigrationsConfiguration _migrationsConfiguration;
        private CSharpCodeProvider _codeProvider;
        private int _migrationAttempts;

        public string MigrationDirectory { get; set; }
        public DatabaseMigrator()
        {
            _codeProvider = new CSharpCodeProvider();
        }

        private void GenerateMigrations()
        {
            
        }

        private CompilerParameters DefaultCompilerParameters()
        {
            var compilerParams = new CompilerParameters();
            compilerParams.ReferencedAssemblies.Add("EntityFramework.dll");
            compilerParams.ReferencedAssemblies.Add("System.Data.dll");
            compilerParams.ReferencedAssemblies.Add("System.Data.Entity.dll");
            compilerParams.ReferencedAssemblies.Add("Core.dll");
            compilerParams.ReferencedAssemblies.Add("System.Core.dll");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.GenerateInMemory = true;
            return compilerParams;
        }

        public void MigrateToLatest()
        {
            if (_migrationAttempts > 2)
            {
                _migrationAttempts = 0;
                return;
            }

            try
            {
                TryMigrate();
                _migrationAttempts = 0;
            }
            catch(AutomaticMigrationsDisabledException)
            {
                _migrationAttempts++;
                GenerateMigrations();
                MigrateToLatest();
            }
        }

        private void TryMigrate()
        {
            // Compile migrations assembly
            var parameters = DefaultCompilerParameters();
            var files = Directory.GetFiles(MigrationDirectory).Where(x => x.EndsWith(".cs"));
            var compiled = _codeProvider.CompileAssemblyFromSource(parameters, files.ToArray());
            // Assign the assembly to migrations configuration
            _migrationsConfiguration.MigrationsAssembly = compiled.CompiledAssembly;
            // Migrate
            var migrator = new DbMigrator(_migrationsConfiguration);
            migrator.Update();
        }
    }
}
