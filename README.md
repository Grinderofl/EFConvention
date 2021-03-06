EFConvention
============

EFConvention is a convention based extension library for Entity Framework to automate several tasks currently cumbersome to do. It allows developers to create an Entity Framework based Context without having to specify each entity by putting it as DbSet<> as property. 

NuGet: http://www.nuget.org/packages/EFConvention/

Basic usage
============

1) Create the context factory
```c#
private IAutoContextFactory _autoContextFactory;
_autoContextFactory = new AutoContextFactory();
_autoContextFactory.AddEntitiesBasedOn<BaseEntity>().AddAssemblyContaining<BaseEntity>();
```

2) Configure the factory

a) Use context factory configuration:
```c#
_autoContextFactory.Configuration.AutoGeneratedMigrationsEnabled = true; 
_autoContextFactory.Configuration.AutoMigrateGeneratedMigrationsEnabled = true;
_autoContextFactory.Configuration.MigrationsDirectory = @"ProjectDir\Migrations";
```
b) Or use conventions:
```c#
public class ConventionConfiguration : IEFConventionConfigurator
{
    public void Configure(IAutoContextFactoryConfiguration configuration)
    {
        configuration.AutoGeneratedMigrationsEnabled = true;
        configuration.AutoMigrateGeneratedMigrationsEnabled = true;
        configuration.MigrationsDirectory = @"ProjectDir\Migrations\";
    }
}
```

3) Create the context and use it
```c#
var context = _autoContextFactory.Context();
context.Set<Item>().Add(new Item());
context.SaveChanges();
```

Detailed info
=============

### Lifecycle
Factory lifecyle should be same as your application lifecycle. First Context() call checks if database has already been migrated, provided AutoMigrateGeneratedMigrationsEnabled is set to true. If you manage migrations manually, lifecycle can be anything and you will be responsible for performance and errors. DbContext lifecycle can be anything you would normally set a standard DbContext to, in Web cases it would be per Request.

### Context
From versioni 2.4, EFConvention uses a standard DbContext. Use the Context() call as such.

Context() call from Factory also accepts a string parameter for connection string, either full connectionstring or the name of it, just like standard DbContext. It's suggested to just set the Connection option under Configuration property, though.

### Configuration
**IAutoContextFactoryConfiguration** provides several configuration options. 
* **MigrationsDirectory** - where you want the program to store its migration files. The files are standard Code First Migration files. This directory should be included in your source control to allow synchronized migrations between developers.

* **AutomaticMigrationsEnabled** - this is an option normally used in standard Code First Migration Configuration as _AutomaticMigrationsEnabled_, having this option on disables the Code Based migration generation.

* **AutomaticMigrationDataLossAllowed** - goes together with AutoMigrateToLatestVersionEnabled, allows data loss on automatic migrations.

* **AutoGeneratedMigrationsEnabled** - option used to specify that, if model has changed, a new migration should be generated. This option exists so programmatic migration generation through Factory could be used.

* **AutoMigrateGeneratedMigrationsEnabled** - option used to specify whether, if model has changed, newly generated migrations should be migrated to database. If this feature is disabled, migrations need to be done programmatically through Factory. If AutoGeneratedMigrationsEnabled is set to false, migrations need to be generated programmatically or migrations will fail.

* **Connection** - your standard connectionstring or connectionstring name

* **MigrationsAssemblyAsFile** - option used if you want migrations to be compiled into a file or loaded from an existing file. Useful if you want to deploy your application but not distribute the .cs  files. Make sure to set the file name.

* **MigrationsAssemblyFileLocation** - name of the file the compiled migration assembly should be saved to. Only functions when MigrationsAssemblyAsFile is true.

**NB! Order of operations is important. Any configuration should be done before Context(), MigrateToLatest() or GenerateMigrations() are called for the first time on Factory, although before migrating, anything ought to work.**

### Factory
* **Configuration** - IAutoContextFactoryConfiguration for configuring the factory

* **AddEntitiesBasedOn&lt;T&gt;()** - This method allows convention based adding of entities to the context. All entities that are not abstract and are based on this class (or these classes, if you add more than one) are automatically added. Assemblies to be searched from also needs to be added.

* **AddEntity&lt;T&gt;()** - Adds a single entity to context.

* **AddAssemblyContaining&lt;T&gt;()** - Adds an assembly which should be searched for convention added classes, which contains specified class.

```c#
public class EntityBase
{
  public int Id { get; set;
}

public class EntityOne : EntityBase {}
public class EntityTwo : EntityBase {}

factory.AddEntitiesBasedOn<EntityBase>().AddAssemblyContaining<EntityOne>(); 
// Adds EntityOne and EntityTwo to context
```

* **AddAssembly(Assembly assembly)** - Adds a single assembly that should be searched for convention-added classes.

* **Context()** - Retrieves the context (and also causes it to be generated if it hasn't yet). If AutoMigrateGeneratedMigrationsEnabled is true, migrations are also run.

* **MigrateToLatest()** - Migrates the database to latest version (and also causes context to be generated if it hasn't yet). If AutoGeneratedMigrationsEnabled is true, missing migrations are automatically generated.

* **GenerateMigrations()** - Generates migrations and saves them under specified migrations directory (and also causes context to be generated if it hasn't yet). _Does not automatically migrate_.

* **IncludedTypes()** - Returns a list of types currently included in the context.
* **AssembliesThatContain()** - Returns a list of assemblies that should be searched.
* **Entities()** - Returns a list of types that are single included in context.
* **EntitiesToBaseOn()** - Returns a list of base types to be used for searching.

**NB! Order of operations is important. Any other method should be called before Context(), MigratToLatest() or GenerateMigrations() are called for the first time on Factory** 

Model Builder Conventions
==========
Starting from version 2.1, EFConvention supports NHibernate-style convention based model building. These classes are IModelBuilderOverride type and take an entity that you wish to map as a generic argument. They will be automatically picked up as long as they're in one of the assemblies you added using ```AddAssemblyContaining<T>()``` or ```AddAssembly(Assembly assembly)```

```c#
public class ItemOverride : IModelBuilderOverride<Item>
{
    public void Configure(EntityTypeConfiguration<Item> entity)
    {
        entity.ToTable("MyTable");
        // Insert your mapping code here
    }
}
```

Listener Conventions
==========
Starting from version 2.1, EFConvention also supports NHibernate style event listeners that can be hooked to different types of events in both pre and post save. Those, too, will be picked up automatically as long as they are located within the assmblies to be searched for items. Full list can be found under ```EFConvention.Interceptors``` namespace. The ```IPreEventListener``` and ```IPostEventListener``` react to any type of entity state.

```c#
public class MyEventListener : IPreInsertEventListener
{
    void OnInsert(DbEntityEntry entityEntry)
    {
        if(entityEntry.Entity is BaseEntity)
            ((BaseEntity)entityEntry.Entity).Created = DateTime.Now;
    }
}
```

Configuration conventions
==========
Starting from version 2.3, EFConvention has a support for automatic EFConvention configuration. Simply create a class that inherits from ```IEFConventionConfigurator``` and either stick it into an assembly that you have added via fluent setup and you're good to go:
```c#
public class ConventionConfiguration : IEFConventionConfigurator
{
    public void Configure(IAutoContextFactoryConfiguration configuration)
    {
        configuration.AutoGeneratedMigrationsEnabled = true;
        configuration.AutoMigrateGeneratedMigrationsEnabled = true;
        configuration.MigrationsDirectory = @"ProjectDir\Migrations\";
    }
}
```
The alternative is, of course, to just configure it when you're setting up your context, such as in Resolve(Component.For()) for Windsor or kernel.Bind<IAutoContextFactory>() for Ninject.

Seeding conventions
==========
Starting from version 2.3, EFConvention also has a support for loading seeding via conventions. EFConvention supports two types of seeding (both can be used concurrently) and as long as they are included in the assembly list, they will be picked up:

* ```IEntitySeed<T>``` - used to seed a single entity. It provides you with a DbSet for this specific object

```c#
public class ItemSeed : IEntitySeed<Item>
{
    public void Seed(DbSet<Item> entity)
    {
        entity.AddOrUpdate(a => a.Data, new Item() {Data = "Hello world", Created = DateTime.Now});
    }
}
```

* ```IContextSeed``` - provides you with the entire DbContext to use.

```c#
public class AllSeed : IContextSeed
{
    public void Seed(DbContext context)
    {
        context.Set<EntityTwo>().AddOrUpdate(x => x.Name, new EntityTwo() {Name = "My entity"});
    }
}
```

Events
==========
**All events fire before their original base events**

### IContext Events
As of version 2.4, IContext has been removed in favor of standard DbContext. 

### IAutoContextFactory Events
* Seeding - executed when database is seeded. Put your AddOrUpdate events here.
```c#
factory.Seeding += (sender, args) => { args.Context.(...); /* args.Context is DbContext */ };
```
* ModelCreating - executed when model is being created. Conventions should be set up here.
```c#
context.ModelCreating += (sender, args) => { args.ModelBuilder.(...);/* args.ModelBuilder is standard DbModelBuilder */};
```
Version history
==========

##### v 2.4.0
* Removed IContext interface as it has lost its purpose now that T4 context generation is gone. Use standard DbContext type instead.

#### v 2.3.4
* Fixed several bugs, such as one that would keep checking database for migrations every time context was requested.

#### v 2.3
* Added convention-based configuration.
* Added support for convention-based seeding

#### v 2.2
* IDbInterceptor-inherited entities are automatically picked up as a convention.

#### v 2.1
* Renamed project to EFConventions and then to EFConvention because EFConventions was already taken on NuGet...
* Added real convention based model builder overrides.
* Added convention based event listeners for post- and pre save states.

#### v 2.0
* Complete rework of migrations and context generation. Now using Reflection instead of T4, allowing the runtime injection of ModelCreating object which wasn't working in version 1.
* Added support for retrieving currently stored entities, base entities and assemblies for Context generation.

#### v 1.0.3
* Context() now accepts a connectionString parameter

#### v 1.0.2
* Context() now has its own lifecycle.

#### v 1.0.1
* Added IncludedTypes() to Factory

#### v 1.0
* Initial release.

TODO
==========
* Perhaps give separate events for async savechanges?
* Add Identity support.

Known bugs
==========
* Might have random file access errors.
