EFAutomation
============

Potentially temporary placeholder repository for an EF Extension Library that permits using Entity Framework 
without having to explicitly create a context. It also allows automatically updating migrations for multiple 
developers and source control. 


Intended Usage (WORK IN PROGRESS, COMPLETE DRAFT VERSION):

### Step 1:
Specify a module which includes your POCO classes with something like
```c#
var contextFactory = new ContextFactory();
contextFactory.AddAssemblyContaining<OneOfPocoClasses>();
```

### Step 2:
Configure seeding and initialization:
```c#
contextFactory.MigrationsDirectory = "..."; // Directory that is under source control.
contextFactory.AddSeed(context => {
  context.Set<OneOfPocoClasses>().AddOrUpdate(...);
}
```

### Step 3:
Use your context in a repository or wherever
```c#
var context = contextFactory.GenerateContext();
var items = context.Set<OneOfPocoClasses>().Where(...);
```


# New (replacing the top part with this soon)
EFAutomation is a convention based extension library for Entity Framework to automate several tasks currently cumbersome to do. It allows developers to create an Entity Framework based Context without having to specify each entity by putting it as DbSet<> as property. 

#### Migrations
EFAutomation supports Code First Migrations - both automatic and, as a new feature - code based automatic. This means that the library generates the Code First files on its own, migrating them as needed, with possibility to choose when and how to migrate.


#### Context
EFAutomation declares an IContext interface which declares effectively same functions as original DbContext and adds some of its own, such as events.

```c#
var contextFactory = new AutoContextFactory();
IContext context = contextFactory.CreateContext();
// Use context as you would normal context
```

#### Events
IContext declares several events.
* SavingChanges
```c#
context.SavingChanges += (sender, args) => { args.Context.(...);/* args.Context is IContext */ };
```

* ModelCreating
```c#
context.ModelCreating += (sender, args) => { args.ModelBuilder.(...);/* args.ModelBuilder is standard DbModelBuilder */};
```

