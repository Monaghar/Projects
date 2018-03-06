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
            Dog Pupper = new Dog() { name = "Woofer", legs = 4, spots = new List<string>(){ "L", "O", "L" } };
            Console.WriteLine(JSONCereal.GetObjectName<Dog>());
            foreach (PropertyInfo thing in JSONCereal.GetPropertyInfo<Dog>())
            {
                Console.WriteLine(thing.Name);
                if (!(JSONCereal.IsPropIenum(Pupper, thing)))
                {
                    Console.WriteLine(JSONCereal.GetPropertyValue(Pupper, thing));
                }
                else
                {                                        
                    foreach (string thiing in thing.GetValue(Pupper, null) as IList)
                    {
                        Console.WriteLine(thiing);
                    }
                }
            }
            Console.ReadKey();
        }
    }
 }
//IList oTheList = piTheList.GetValue(MyObject, null) as IList;