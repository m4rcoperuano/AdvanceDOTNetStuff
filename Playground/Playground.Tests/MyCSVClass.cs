using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Playground.Tests
{
    public delegate string MyModification (string n);
    public class MyCSVClass
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string ExecuteModification(MyModification del)
        {
            return del(this.Name);
        }
    }
}
