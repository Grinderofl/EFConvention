using System;
using System.Reflection;

namespace EFConventions
{
    // Possible future class to use appdomain for loading the generators
    internal class ProxyDomain : MarshalByRefObject
    {
        public Assembly GetAssembly(string assemblyPath)
        {
            try
            {
                return Assembly.LoadFrom(assemblyPath);
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException("", ex);
            }
        }
    }
}
