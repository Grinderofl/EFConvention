namespace Test
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
        }
    }
}
//using System;
//using System.CodeDom.Compiler;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Data.Entity.Core.EntityClient;
//using System.Data.Entity.Migrations;
//using System.Data.Entity.Migrations.Design;
//using System.Data.Entity.Migrations.Infrastructure;
//using System.Data.Entity.Migrations.Model;
//using System.Globalization;
//using System.IO;
//using System.Linq;
//using System.Reflection;
//using System.Resources;
//using System.Text;
//using System.Threading.Tasks;
//using EFAutomation;
//using Microsoft.CSharp;

//namespace Test
//{
//    internal class Program
//    {
//        private static void Main(string[] args)
//        {
//            Assembly.GetAssembly(typeof (Item));

//            var generated = new GeneratedContext();
//            generated.Session = new Dictionary<string, object>();
//            var types = Assembly.GetAssembly(typeof (Item))
//                .GetTypes()
//                .Where(x => x.IsSubclassOf(typeof (Entity)) && !x.IsAbstract).ToList();
//            generated.Session["Types"] = types;
            
//            generated.Initialize();
//            var transformed = generated.TransformText();
//            var provider = new CSharpCodeProvider();
//            var compilerParams = new CompilerParameters();

//            var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Migrations\\";

//            //compilerParams.GenerateInMemory = true;
//            compilerParams.GenerateInMemory = false;
//            compilerParams.OutputAssembly = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Context.dll";
//            compilerParams.ReferencedAssemblies.Add("EntityFramework.dll");
//            compilerParams.ReferencedAssemblies.Add("System.Data.dll");
//            compilerParams.ReferencedAssemblies.Add("System.Data.Entity.dll");
//            compilerParams.ReferencedAssemblies.Add("Core.dll");
//            compilerParams.ReferencedAssemblies.Add("System.Core.dll");
//            compilerParams.ReferencedAssemblies.Add("System.dll");
//            compilerParams.ReferencedAssemblies.Add(Assembly.GetAssembly(typeof(IContext)).Location);
            
//            var contextAssembly = provider.CompileAssemblyFromSource(compilerParams, transformed);
//            var context =
//                (IContext)
//                    contextAssembly.CompiledAssembly.CreateInstance("EFMigrations.Context", false, BindingFlags.CreateInstance, null,
//                        new object[] {"DefaultConnection"}, CultureInfo.CurrentCulture, null);

            
//            var configuration = (DbMigrationsConfiguration)contextAssembly.CompiledAssembly.CreateInstance("EFMigrations.Configuration");
            
//            var scaffolder = new MigrationScaffolder(configuration) {Namespace = "EFMigrations"};
//            //var scaffold = scaffolder.Scaffold(DateTime.Now.ToString("hh_mm_ss"));
//            var scaffold = scaffolder.Scaffold("First");
//            Directory.CreateDirectory(directory);
//            //File.WriteAllText(directory + scaffold.MigrationId + ".cs", scaffold.UserCode);
//            var designerGenerator = new MigrationDesignerGenerator();
//            designerGenerator.Session = new Dictionary<string, object>();
//            designerGenerator.Session.Add("Target", scaffold.Resources["Target"]);
//            designerGenerator.Session.Add("MigrationId", scaffold.MigrationId);
//            designerGenerator.Initialize();
//            //File.WriteAllText(directory + scaffold.MigrationId + ".Designer.cs", designerGenerator.TransformText());
//            //using (var writer = new ResXResourceWriter(directory + "EFMigrations." + scaffold.MigrationId.Substring(scaffold.MigrationId.IndexOf("_", StringComparison.Ordinal)+1) + ".resources"))
//            //    foreach (var resource in scaffold.Resources)
//            //        writer.AddResource(resource.Key, resource.Value);
                
//            var filesContents = Directory.GetFiles(directory).Where(x => x.EndsWith(".cs")).Select(File.ReadAllText).ToList();
//            //var resources = Directory.GetFiles(directory).Where(x => x.EndsWith(".resx"));
//            //foreach (var res in resources)

//                //compilerParams.OutputAssembly = "AutomatedMigrations.dll";
//                //foreach (var resource in resources) 
//                //compilerParams.CompilerOptions += string.Format("/resource:\"{0}\" ", resource);
//            //compilerParams.EmbeddedResources.AddRange(resources.ToArray());
//            //compilerParams.GenerateInMemory = true;
//            compilerParams.OutputAssembly = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Migrations.dll";

//            var migrationsAssembly = provider.CompileAssemblyFromSource(compilerParams, filesContents.ToArray());

            
//            configuration.MigrationsAssembly = migrationsAssembly.CompiledAssembly;
//            configuration.MigrationsNamespace = "EFMigrations";
//            //configuration.MigrationsDirectory = "Test\\bin\\Debug\\Migrations\\";*/
//            var migrator = new DbMigrator(configuration);
//            var pending = migrator.GetPendingMigrations();
//            //var resManager = new ResourceManager("EFMigrations.First", assemblies.CompiledAssembly);
//            //var ress = resManager.GetResourceSet(CultureInfo.InvariantCulture, false, true);
//            migrator.Update("");

//            var decorator = new MigratorScriptingDecorator(migrator);
//            var codegenerator = new CSharpMigrationCodeGenerator();
            
//            //context.Set<Item>().Add(new Item() {Stuff = "Hello"});
//            context.SaveChanges();
//            Console.Read();
            
//        }
//    }
//}

