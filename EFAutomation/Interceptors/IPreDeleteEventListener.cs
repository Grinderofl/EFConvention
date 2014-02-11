<<<<<<< HEAD
﻿using System.Data.Entity.Infrastructure;

namespace EFConventions.Interceptors
=======
﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAutomation.Interceptors
>>>>>>> cf4659b760e07050a0426662dd0cba0acde539aa
{
    /// <summary>
    /// 
    /// </summary>
    public interface IPreDeleteEventListener
    {
        void OnDelete(DbEntityEntry entry);
    }
}
