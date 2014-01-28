using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class Item :  EntityWithGuidId
    {
        public string Stuff { get; set; }
        public string MoreStuff { get; set; }
    }
}
