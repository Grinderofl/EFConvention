using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFConvention
{
    /// <summary>
    /// EventHandler for model creation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e">ModelBuilder EventArgs</param>
    public delegate void ModelCreatingEventHandler(object sender, ModelBuilderEventArgs e);
    /// <summary>
    /// EventHandler for saving changes
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e">SavingChanges EventArgs</param>
    public delegate void SavingChangesEventHandler(object sender, SavingChangesEventArgs e);
    /// <summary>
    /// EventHandler for Validating Entity
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e">ValidatingEntity EventArgs</param>
    public delegate void ValidatingEntityEventHandler(object sender, ValidatingEntityEventArgs e);
}
