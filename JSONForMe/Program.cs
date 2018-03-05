using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

 namespace JSONForMe
 {
    class Program
    {
        static void Main(string[] args)
        {
            Dog Pupper = new Dog() { name = "Woofer", legs = 4 };
            Console.WriteLine(JSONCereal.GetObjectName(Pupper));
            foreach (PropertyInfo thing in JSONCereal.GetProps(Pupper))
            {
                Console.WriteLine(thing.Name);
                Console.WriteLine(JSONCereal.GetPropertyValue(Pupper, thing));
            }
            Console.ReadKey();
        }
    }
 }