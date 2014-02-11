using System;
using System.Collections.Generic;
using System.Reflection;

namespace EFConventions
{
    /// <summary>
    /// Auto Context Factory interface
    /// </summary>
    public interface IAutoContextFactory
    {
        /// <summary>
        /// Gets or sets context factory configuration
        /// </summary>
        IAutoContextFactoryConfiguration Configuration { get; set; }
        /// <summary>
        /// Adds all objects that are extending from this base class that are not abstract to the context
        /// </summary>
        /// <typeparam name="T">Class which' inheritors are to be added to the context</typeparam>
        /// <returns>AutoContextFactory for fluent chaining</returns>
        IAutoContextFactory AddEntitiesBasedOn<T>() where T : class;
        /// <summary>
        /// Adds a single object to context
        /// </summary>
        /// <typeparam name="T">Class to add</typeparam>
        /// <returns>AutoContextFactory for fluent chaining</returns>
        IAutoContextFactory AddEntity<T>() where T : class;
        /// <summary>
        /// Adds assembly which is to be used to search inherited classes from.
        /// </summary>
        /// <typeparam name="T">Class that is contained within the required assembly</typeparam>
        /// <returns>AutoContextFactory for fluent chaining</returns>
        IAutoContextFactory AddAssemblyContaining<T>() where T : class;
        /// <summary>
        /// Adds assembly to be used to search inherited classes from.
        /// </summary>
        /// <param name="assembly">Assembly to add</param>
        /// <returns>AutoContextFactory for fluent chaining</returns>
        IAutoContextFactory AddAssembly(Assembly assembly);

        /// <summary>
        /// Gets all included types in the context
        /// </summary>
        /// <returns></returns>
        List<Type> IncludedTypes();

        /// <summary>
        /// Creates the context
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns>Created IContext</returns>
        IContext Context(string connectionString = "");
        /// <summary>
        /// Migrates database to latest version
        /// </summary>
        void MigrateToLatest();
        /// <summary>
        /// Generates freshest migrations
        /// </summary>
        void GenerateMigrations();

        /// <summary>
        /// Event that is fired on seeding the database
        /// </summary>
        event SeedingEventHandler Seeding;

        /// <summary>
        /// Lists all assemblies that are searched for entities to be included in Context that are based on a Base Entity.
        /// </summary>
        /// <returns>List of assemblies</returns>
        List<Assembly> AssembliesThatContain();

        /// <summary>
        /// Lists all single types that are to be included in the context.
        /// </summary>
        /// <returns>List of types</returns>
        List<Type> Entities();

        /// <summary>
        /// Lists all types 
        /// </summary>
        /// <returns></returns>
        List<Type> EntitiesToBaseOn();

    }
}