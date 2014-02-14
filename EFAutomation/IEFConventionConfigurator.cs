using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConvention
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEFConventionConfigurator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        void Configure(IAutoContextFactoryConfiguration configuration);
    }
}
