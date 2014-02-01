using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebTest.Models
{
    public class Item
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public string Data { get; set; }
        public string Data2 { get; set; }
        public string Data3 { get; set; }
        public int Data5 { get; set; }
        public int Data6 { get; set; }
        public bool TestBool { get; set; }
    }
}