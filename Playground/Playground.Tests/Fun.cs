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
    public class Fun
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
            csvClass.Name = " hello World ";
            csvClass.Address = "stuff 123";
            csvClass.ZipCode = "22222";
            MyModification removeSpaces = new MyModification(x=>x.Trim());
            string result = csvClass.ExecuteModification(x=>x.Trim());


            dynamic props = new ExpandoObject();

            values = csvClass.GetType()
                .GetProperties().
                ToDictionary(x => x.Name, x => x.GetValue(csvClass, null))
                .Select(x=> x.Value.ToString()).ToList<string>();


            Assert.AreEqual(result, "hello World");
        }

        //helper methods
        public double GetTheModifiedSpeed(IVehicles vehicle)
        {
            return vehicle.GetSpeed() + 70;
        }
        public string removeSpaces(string input)
        {
            return input.Trim();
        }
    }
}
