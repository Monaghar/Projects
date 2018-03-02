using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONForMe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog Pupper = new Dog() { Name = "Woofer" };
            Console.WriteLine(JSONCereal.Cerial(Pupper));
            Console.ReadKey();
        }
    }
}