using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.Models
{
    public class Item : BaseEntity
    {
        public DateTime Created { get; set; }
        public string Data { get; set; }
        public bool Boolean { get; set; }
        public bool Boolean2 { get; set; }
        public string Data3 { get; set; }
    }
}