using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFAutomation
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
