using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Using_The_DLR
{
    class Employee
    {
        public string FirstName { get; set; }
        public string Speak()
        {
            return "Hello " + this.FirstName;
        }

    }
}
