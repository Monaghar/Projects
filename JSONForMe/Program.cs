using System;
using System.Collections.Generic;
using System.Collections;
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
            Dog Pupper = new Dog() { name = "Woofer", legs = 4, spots = new List<string>(){ "L", "O", "3" } };
            Console.WriteLine(JSONCereal.PrintToJSON(Pupper));
            Console.ReadKey();
        }
    }
 }