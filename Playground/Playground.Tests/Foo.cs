using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Playground.Classes;
using Playground.Interfaces;
using System.Dynamic;

namespace Playground.Tests
{
    [TestClass]
    public class CarStuff
    {
        [TestMethod]
        public void Operations()
        {
            //a car has a speed property
            Car car = new Car();
            car.Speed = 50;
            //need to retrieve it
            double modifiedSpeed = this.GetTheModifiedSpeed(car);
            Assert.AreEqual(car.Speed + 70, modifiedSpeed);
        }

        [TestMethod]
        public void GenerateCSV()
        {
            //take a class full of properties
            MyCSVClass csvClass = new MyCSVClass();
            List<string> values = new List<string>();
            //break it into a dictionary object
            csvClass.Name = "hello World";
            csvClass.Address = "stuff 123";
            csvClass.ZipCode = "22222";

            dynamic props = new ExpandoObject();
            
            var properties = csvClass.GetType().GetProperties().ToDictionary(x => x.Name, x => x.GetValue(csvClass, null));
            foreach (var prop in properties)
            {
               
                values.Add(prop.Value.ToString());
            }
            Assert.AreEqual(values.Count, 3);
        }

        //helper methods
        public double GetTheModifiedSpeed(IVehicles vehicle)
        {
            return vehicle.GetSpeed() + 70;
        }
    }
}
