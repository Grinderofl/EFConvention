using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConvention
{
    /// <summary>
    /// Configures Entity Framework Convention Factory
    /// </summary>
    public interface IEFConventionConfigurator
    {
        /// <summary>
        /// Configures EF Context Factory
        /// </summary>
        /// <param name="configuration"></param>
        void Configure(IAutoContextFactoryConfiguration configuration);
    }
}
