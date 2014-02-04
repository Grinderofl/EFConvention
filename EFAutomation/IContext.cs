using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EFAutomation
{
    /// <summary>
    /// Context interface
    /// </summary>
    public interface IContext : IDisposable, IObjectContextAdapter
    {
        /// <summary>
        /// Provides access to features of the context that deal with change tracking of entities.
        /// </summary>
        DbChangeTracker ChangeTracker { get; }
        /// <summary>
        /// Provides access to configuration options for the context.
        /// </summary>
        DbContextConfiguration Configuration { get; }
        /// <summary>
        /// Creates a Database instance for this context that allows for creation/deletion/existence checks for the underlying database.
        /// </summary>
        Database Database { get; }

        /// <summary>
        /// Gets a DbEntityEntry object for the given entity providing access to information about the entity and the ability to perform actions on the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>An entry for the entity.</returns>
        DbEntityEntry Entry(object entity);
        /// <summary>
        /// Gets a DbEntityEntry object for the given entity providing access to information about the entity and the ability to perform actions on the entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns>An entry for the entity.</returns>
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        /// <summary>
        /// Validates tracked entities and returns a Collection of DbEntityValidationResult containing validation results.
        /// </summary>
        /// <returns>Collection of validation results for invalid entities. The collection is never null and must not contain null values or results for valid entities.</returns>
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        /*/// <summary>
        /// This method is called when the model for a derived context has been initialized, but before the model has been locked down and used to initialize the context. The default implementation of this method does nothing, but it can be overridden in a derived class such that the model can be further configured before it is locked down.
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        void OnModelCreating(DbModelBuilder modelBuilder);*/
        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>The number of objects written to the underlying database.</returns>
        int SaveChanges();
        /// <summary>
        /// Asynchronously saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation. The task result contains the number of objects written to the underlying database.</returns>
        Task<int> SaveChangesAsync();
        /// <summary>
        /// Asynchronously saves all changes made in this context to the underlying database.
        /// </summary>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous save operation. The task result contains the number of objects written to the underlying database.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        /// <summary>
        /// Returns a non-generic DbSet instance for access to entities of the given type in the context, the ObjectStateManager, and the underlying store.
        /// 
        /// </summary>
        /// <param name="entityType">The type entity for which a set should be returned.</param>
        /// <returns>A set for the given entity type.</returns>
        DbSet Set(Type entityType);
        /// <summary>
        /// Returns a DbSet instance for access to entities of the given type in the context, the ObjectStateManager, and the underlying store.
        /// </summary>
        /// <typeparam name="TEntity">The type of entity for which a set should be returned.</typeparam>
        /// <returns>A set for the given entity type.</returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        /// <summary>
        /// Extension point allowing the user to override the default behavior of validating only added and modified entities.
        /// </summary>
        /// <param name="entityEntry">DbEntityEntry instance that is supposed to be validated.</param>
        /// <returns>true to proceed with validation; false otherwise.</returns>
        bool ShouldValidateEntity(DbEntityEntry entityEntry);
        /// <summary>
        /// Extension point allowing the user to customize validation of an entity or filter out validation results. Called by GetValidationErrors().
        /// </summary>
        /// <param name="entityEntry">DbEntityEntry instance to be validated.</param>
        /// <param name="items"></param>
        /// <returns>User-defined dictionary containing additional info for custom validation. It will be passed to ValidationContext and will be exposed as Items. This parameter is optional and can be null.</returns>
        DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<Object, Object> items);

        /// <summary>
        /// Event that occurs when changes are being saved
        /// </summary>
        event SavingChangesEventHandler SavingChanges;
        /// <summary>
        /// Event that occurs when entity is being validated
        /// </summary>
        event ValidatingEntityEventHandler ValidatingEntity;

    }

    /// <summary>
    /// EventHandler for model creation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e">ModelBuilder EventArgs</param>
    public delegate void ModelCreatingEventHandler(object sender, ModelBuilderEventArgs e);
    /// <summary>
    /// EventHandler for saving changes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e">SavingChanges EventArgs</param>
    public delegate void SavingChangesEventHandler(object sender, SavingChangesEventArgs e);
    /// <summary>
    /// EventHandler for Validating Entity
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e">ValidatingEntity EventArgs</param>
    public delegate void ValidatingEntityEventHandler(object sender, ValidatingEntityEventArgs e);
}
