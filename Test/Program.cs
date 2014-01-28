using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Design;
using System.Data.Entity.Migrations.Infrastructure;
using System.Data.Entity.Migrations.Model;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Core;
using EFAutomation;
using Microsoft.CSharp;

namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Assembly.GetAssembly(typeof (Item));

            var generated = new GeneratedContext();
            var transformed = generated.TransformText();
            var provider = new CSharpCodeProvider();
            var compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.OutputAssembly = "Automated";
            compilerParams.ReferencedAssemblies.Add("EntityFramework.dll");
            compilerParams.ReferencedAssemblies.Add("System.Data.dll");
            compilerParams.ReferencedAssemblies.Add("System.Data.Entity.dll");
            compilerParams.ReferencedAssemblies.Add("Core.dll");
            compilerParams.ReferencedAssemblies.Add("System.Core.dll");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            var icc = provider.CompileAssemblyFromSource(compilerParams, transformed);
            var context =
                (DbContext)
                    icc.CompiledAssembly.CreateInstance("EFMigrations.Context", false, BindingFlags.CreateInstance, null,
                        new object[] {"DefaultConnection"}, CultureInfo.CurrentCulture, null);

            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Migrations\\";

            var configuration = (DbMigrationsConfiguration)icc.CompiledAssembly.CreateInstance("EFMigrations.Configuration", false, BindingFlags.CreateInstance, null, null, CultureInfo.CurrentCulture, null);
            
            var scaffolder = new MigrationScaffolder(configuration);
            var scaffold = scaffolder.Scaffold(DateTime.Now.ToString("hh_mm_ss"));
            Directory.CreateDirectory(directory);
            File.WriteAllText(directory + scaffold.MigrationId + ".designer.cs", scaffold.DesignerCode);
            File.WriteAllText(directory + scaffold.MigrationId + ".cs", scaffold.UserCode);
            using (var writer = new ResXResourceWriter(directory + scaffold.MigrationId + ".resources"))
            {
                foreach (var resource in scaffold.Resources)
                {
                    writer.AddResource(resource.Key, resource.Value);
                }
            }

            var filesContents = Directory.GetFiles(directory).Where(x => x.EndsWith(".cs")).Select(File.ReadAllText).ToList();
            var resources = Directory.GetFiles(directory).Where(x => x.EndsWith(".resources"));
            compilerParams.OutputAssembly = "AutomatedMigrations";
            compilerParams.EmbeddedResources.AddRange(resources.ToArray());
            
            var assemblies = provider.CompileAssemblyFromSource(compilerParams, filesContents.ToArray());

            
            configuration.MigrationsAssembly = assemblies.CompiledAssembly;
            configuration.MigrationsNamespace = "EFMigrations";
            var migrator = new DbMigrator(configuration);
            migrator.Update();

            var decorator = new MigratorScriptingDecorator(migrator);
            var codegenerator = new CSharpMigrationCodeGenerator();
            
            context.Set<Item>().Add(new Item() {Stuff = "Hello"});
            context.SaveChanges();
            Console.Read();
            
        }
    }

    public class MigrationsConfiguration : DbMigrationsConfiguration<DbContext>
    {
        
    }
}

