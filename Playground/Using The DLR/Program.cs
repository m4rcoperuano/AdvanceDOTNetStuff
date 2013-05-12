using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Using_The_DLR
{
    class Program
    {
        static void Main(string[] args)
        {
            dynamic obj = GetASpeaker();
            dynamic expando = new ExpandoObject(); //dictionary string, object
            expando.Name = "Marco Ledesma";
            expando.Speak = new Action(() => Console.WriteLine(expando.Name));
            
            //expando.Speak();

            foreach (var member in expando)
            {
                Console.WriteLine(member.Key);
            }

            Console.WriteLine(obj.Speak());
            Console.Read();
        }

        public static object GetASpeaker()
        {
            return new Employee { FirstName = "Marco" };
        }
    }
}
