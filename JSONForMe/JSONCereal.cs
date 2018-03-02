using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace JSONForMe
{
    public static class JSONCereal
    {


        public static string Cerial(object obj)
        {
            var type = obj.GetType();
            var things = type.GetProperties();
            StringBuilder bobTheBuilder = new StringBuilder();
            foreach(PropertyInfo info in things)
            {
                bobTheBuilder.Append(info);
            }
            return bobTheBuilder.ToString();
        }
    }
} 