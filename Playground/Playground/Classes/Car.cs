using Playground.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Playground.Classes
{
    public class Car : IVehicles
    {
        public double GetSpeed()
        {
            return this.Speed;
        }

        public double Speed { get; set; }
    }
}