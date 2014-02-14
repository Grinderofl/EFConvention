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
    public interface IContextSeed
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        void Seed(IContext context);
    }
}
