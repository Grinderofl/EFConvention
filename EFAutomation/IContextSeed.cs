using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConvention
{
    /// <summary>
    /// Performs seeding on entire context
    /// </summary>
    public interface IContextSeed
    {
        /// <summary>
        /// Seed the context
        /// </summary>
        /// <param name="context"></param>
        void Seed(IContext context);
    }
}
