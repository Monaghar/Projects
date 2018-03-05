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
        public static StringBuilder bobTheBuilder = new StringBuilder();

        //gets the object name
        public static string GetObjectName(object obj)
        {
            return obj.GetType().Name;
        }

        //gets the properties of an object into a string list
        public static List<PropertyInfo> GetProps(object obj)
        {
            List<PropertyInfo> tempPropList = new List<PropertyInfo>();
            foreach (var thing in obj.GetType().GetProperties())
            {
                tempPropList.Add(thing);
            }
            return tempPropList;
        }

        // gets value from property
        public static string GetPropertyValue(object obj, PropertyInfo property)
        {
            return property.GetValue(obj, null).ToString();
        }

        //gets strings from sting list
        //public static string GetNameFromList(List<string> strList)
        //{
        //    for (int i = 0; i < strList.Count; i++)
        //    {
        //        bobTheBuilder.Append(GetPropName(strList, i));
        //    }
        //    return bobTheBuilder.ToString();
        //}

        //gets individual names from list
        //public static string GetPropName(List<string> strList, int numb)
        //{
        //    return strList[numb];
        //}
    }
}