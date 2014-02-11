using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using EFConventions.Interceptors;

namespace EFConventions
{
    /// <summary>
    /// Context implementation
    /// </summary>
    public class Context : DbContext, IContext
    {
        private readonly List<Type> _baseTypes;
        private readonly List<Type> _entities;
        private readonly List<Assembly> _assemblies;

        private delegate void ListenerEventHandler(DbEntityEntry entry);

        private readonly ListenerEventHandler _preInsert;
        private readonly ListenerEventHandler _preDelete;
        private readonly ListenerEventHandler _preDetach;
        private readonly ListenerEventHandler _preModified;
        private readonly ListenerEventHandler _preUnchanged;
        private readonly ListenerEventHandler _preAny;

        private readonly ListenerEventHandler _postInsert;
        private readonly ListenerEventHandler _postDelete;
        private readonly ListenerEventHandler _postDetach;
        private readonly ListenerEventHandler _postModified;
        private readonly ListenerEventHandler _postUnchanged;
        private readonly ListenerEventHandler _postAny;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="assemblies">Assemblies to search from</param>
        /// <param name="entities">Entities to add</param>
        /// <param name="baseTypes">Entities based off of to add from within Assemblies to search from</param>
        /// <param name="connectionString">Database connection string</param>
        public Context(List<Assembly> assemblies, List<Type> entities, List<Type> baseTypes, string connectionString) : base(connectionString)
        {
            _assemblies = assemblies;
            _entities = entities;
            _baseTypes = baseTypes;
            

            foreach (var assembly in _assemblies)
            {
                foreach (var type in assembly.GetTypes().Where(x => !x.IsInterface))
                {
                    if (InterfaceContains(type, typeof(IPreInsertEventListener)))
                    {
                        var insert = (IPreInsertEventListener) Activator.CreateInstance(type);
                        _preInsert += insert.OnInsert;
                    }
                    if (InterfaceContains(type, typeof (IPreDeleteEventListener)))
                    {
                        var update = (IPreDeleteEventListener) Activator.CreateInstance(type);
                        _preDelete += update.OnDelete;
                    }
                    if (InterfaceContains(type, typeof(IPreDetachedEventListener)))
                    {
                        var update = (IPreDetachedEventListener)Activator.CreateInstance(type);
                        _preDetach += update.OnDetach;
                    }
                    if (InterfaceContains(type, typeof(IPreUpdateEventListener)))
                    {
                        var update = (IPreDetachedEventListener)Activator.CreateInstance(type);
                        _preModified += update.OnDetach;
                    }
                    if (InterfaceContains(type, typeof(IPreUnchangedEventListener)))
                    {
                        var update = (IPreUnchangedEventListener)Activator.CreateInstance(type);
                        _preUnchanged += update.OnUnchanged;
                    }
                    if (InterfaceContains(type, typeof (IPreEventListener)))
                    {
                        var any = (IPreEventListener) Activator.CreateInstance(type);
                        _preAny += any.OnEvent;
                    }



                    if (InterfaceContains(type, typeof(IPostInsertEventListener)))
                    {
                        var insert = (IPostInsertEventListener)Activator.CreateInstance(type);
                        _postInsert += insert.OnInsert;
                    }
                    if (InterfaceContains(type, typeof(IPostDeleteEventListener)))
                    {
                        var update = (IPostDeleteEventListener)Activator.CreateInstance(type);
                        _postDelete += update.OnDelete;
                    }
                    if (InterfaceContains(type, typeof(IPostDetachedEventListener)))
                    {
                        var update = (IPostDetachedEventListener)Activator.CreateInstance(type);
                        _postDetach += update.OnDetach;
                    }
                    if (InterfaceContains(type, typeof(IPostUpdateEventListener)))
                    {
                        var update = (IPostDetachedEventListener)Activator.CreateInstance(type);
                        _postModified += update.OnDetach;
                    }
                    if (InterfaceContains(type, typeof(IPostUnchangedEventListener)))
                    {
                        var update = (IPostUnchangedEventListener)Activator.CreateInstance(type);
                        _postUnchanged += update.OnUnchanged;
                    }
                    if (InterfaceContains(type, typeof(IPostEventListener)))
                    {
                        var any = (IPostEventListener)Activator.CreateInstance(type);
                        _postAny += any.OnEvent;
                    }
                    
                }
            }

            SavingChanges += (sender, args) =>
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    if (entry.State == EntityState.Added && _preInsert != null)
                        _preInsert(entry);
                    if (entry.State == EntityState.Deleted && _preDelete != null)
                        _preDelete(entry);
                    if (entry.State == EntityState.Detached && _preDetach != null)
                        _preDetach(entry);
                    if (entry.State == EntityState.Modified &&  _preModified != null)
                        _preModified(entry);
                    if (entry.State == EntityState.Unchanged && _preUnchanged != null)
                        _preUnchanged(entry);
                    if(_preAny != null)
                        _preAny(entry);
                }
            };

            PostSavingChanges += (sender, args) =>
            {
                foreach (var entry in ChangeTracker.Entries())
                {
                    if (entry.State == EntityState.Added && _postInsert != null)
                        _postInsert(entry);
                    if (entry.State == EntityState.Deleted && _postDelete != null)
                        _postDelete(entry);
                    if (entry.State == EntityState.Detached && _postDetach != null)
                        _postDetach(entry);
                    if (entry.State == EntityState.Modified && _postModified != null)
                        _postModified(entry);
                    if (entry.State == EntityState.Unchanged && _postUnchanged != null)
                        _postUnchanged(entry);
                    if(_postAny != null)
                        _postAny(entry);
                }
            };

        }

        private bool InterfaceContains(Type type, Type contains)
        {
            return type.GetInterfaces().Contains(contains);
        }

        /// <summary>
        /// Extension point allowing the user to override the default behavior of validating only added and modified entities.
        /// </summary>
        /// <param name="entityEntry">DbEntityEntry instance that is supposed to be validated.</param>
        /// <returns>true to proceed with validation; false otherwise.</returns>
        public new bool ShouldValidateEntity(DbEntityEntry entityEntry)
        {
            return base.ShouldValidateEntity(entityEntry);
        }

        /// <summary>
        /// Extension point allowing the user to customize validation of an entity or filter out validation results. Called by GetValidationErrors().
        /// </summary>
        /// <param name="entityEntry">DbEntityEntry instance to be validated.</param>
        /// <param name="items"></param>
        /// <returns>User-defined dictionary containing additional info for custom validation. It will be passed to ValidationContext and will be exposed as Items. This parameter is optional and can be null.</returns>
        public new DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            if (ValidatingEntity != null)
                ValidatingEntity(this, new ValidatingEntityEventArgs() {EntityEntry = entityEntry, Items = items});
            return base.ValidateEntity(entityEntry, items);
        }

        /// <summary>
        /// Event that occurs when changes are being saved
        /// </summary>
        public event SavingChangesEventHandler SavingChanges;

        /// <summary>
        /// Event that occurs after changes are saved
        /// </summary>
        public event SavingChangesEventHandler PostSavingChanges;

        /// <summary>
        /// Event that occurs when entity is being validated
        /// </summary>
        public event ValidatingEntityEventHandler ValidatingEntity;
        
        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>The number of objects written to the underlying database.</returns>
        public override int SaveChanges()
        {
            if (SavingChanges != null)
                SavingChanges(this, new SavingChangesEventArgs() {Context = this});
            
            var result = base.SaveChanges();
            if (PostSavingChanges != null)
                PostSavingChanges(this, new SavingChangesEventArgs() {Context = this});
            return result;
        }

        /// <summary>
        /// Asynchronously saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation. The task result contains the number of objects written to the underlying database.</returns>
        public override Task<int> SaveChangesAsync()
        {
            if (SavingChanges != null)
                SavingChanges(this, new SavingChangesEventArgs() { Context = this });
            var result = base.SaveChangesAsync();
            if (PostSavingChanges != null)
                PostSavingChanges(this, new SavingChangesEventArgs() { Context = this });
            return result;
        }

        /// <summary>
        /// Asynchronously saves all changes made in this context to the underlying database.
        /// </summary>
        /// <param name="cancellationToken">A CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous save operation. The task result contains the number of objects written to the underlying database.</returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            if (SavingChanges != null)
                SavingChanges(this, new SavingChangesEventArgs() { Context = this });
            var result = base.SaveChangesAsync(cancellationToken);
            if (PostSavingChanges != null)
                PostSavingChanges(this, new SavingChangesEventArgs() { Context = this });
            return result;
        }

        /// <summary>
        /// This method is called when the model for a derived context has been initialized, but
        ///             before the model has been locked down and used to initialize the context.  The default
        ///             implementation of this method does nothing, but it can be overridden in a derived class
        ///             such that the model can be further configured before it is locked down.
        /// </summary>
        /// <remarks>
        /// Typically, this method is called only once when the first instance of a derived context
        ///             is created.  The model for that context is then cached and is for all further instances of
        ///             the context in the app domain.  This caching can be disabled by setting the ModelCaching
        ///             property on the given ModelBuidler, but note that this can seriously degrade performance.
        ///             More control over caching is provided through use of the DbModelBuilder and DbContextFactory
        ///             classes directly.
        /// </remarks>
        /// <param name="modelBuilder">The builder that defines the model for the context being created. </param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entityMethod = typeof (DbModelBuilder).GetMethod("Entity");

            foreach (var assembly in _assemblies)
            {
                foreach (var type in _baseTypes)
                {
                    var type1 = type;
                    var entityTypes = assembly.GetTypes().Where(x => !x.IsAbstract && x.IsSubclassOf(type1));

                    foreach (var t in entityTypes)
                        entityMethod.MakeGenericMethod(t).Invoke(modelBuilder, new object[] {});
                }
            }
            foreach (var type in _entities)
                entityMethod.MakeGenericMethod(type).Invoke(modelBuilder, new object[] {});

            if (ModelCreating != null)
                ModelCreating(this, new ModelBuilderEventArgs() {ModelBuilder = modelBuilder});
        }

        internal ModelCreatingEventHandler ModelCreating;
    }

    /// <summary>
    /// Context Factory
    /// </summary>
    public class ContextFactory : IDbContextFactory<Context>
    {
        public Context Create()
        {
            var current = AutoContextFactory.Current;

            var context = new Context(current.AssembliesThatContain(), current.Entities(), current.EntitiesToBaseOn(),
                current.Configuration.Connection);
            context.ModelCreating += current.OnModelCreating;

            return context;
        }
    }
}
