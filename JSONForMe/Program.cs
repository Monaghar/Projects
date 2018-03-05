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
            Dog Pupper = new Dog() { Name = "Woofer", Legs = 4 };
            foreach (string thing in JSONCereal.GetPropNames(Pupper))
            {
                int i = 0;
                Console.WriteLine(thing);
                Console.WriteLine(JSONCereal.GetPropertyValue(Pupper, JSONCereal.GetPropName(JSONCereal.GetPropNames(Pupper), i)));
                i++;
            }
            //Console.WriteLine(JSONCereal.GetPropertyValue(Pupper, JSONCereal.GetPropName(JSONCereal.GetPropNames(Pupper), 0)));
            //Console.WriteLine(JSONCereal.GetPropertyValue(Pupper, JSONCereal.GetNameFromList
            //                 (JSONCereal.GetPropNames())));
            Console.ReadKey();
        }
    }
 }