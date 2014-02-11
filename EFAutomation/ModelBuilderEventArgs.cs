using System;
using System.Data.Entity;

namespace EFConvention
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelBuilderEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public DbModelBuilder ModelBuilder { get; set; }
    }
}
