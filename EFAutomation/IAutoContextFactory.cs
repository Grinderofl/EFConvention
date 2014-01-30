using System.Reflection;

namespace EFAutomation
{
    public interface IAutoContextFactory
    {
        IAutoContextFactoryConfiguration Configuration { get; set; }
        IAutoContextFactory AddEntitiesBasedOn<T>() where T : class;
        IAutoContextFactory AddEntity<T>() where T : class;
        IAutoContextFactory AddAssemblyContaining<T>() where T : class;
        IAutoContextFactory AddAssembly(Assembly assembly);
        IContext Create();
        void MigrateToLatest();
    }
}