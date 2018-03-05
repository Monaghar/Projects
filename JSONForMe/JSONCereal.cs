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

        //gets the properties of an object into a string list
        public static List<string> GetPropNames(object obj)
        {
            List<string> tempStrList = new List<string>(obj.GetType().GetProperties().Count());
            foreach (var thing in obj.GetType().GetProperties())
            {
                tempStrList.Add(thing.Name);
            }
            return tempStrList;
        }

        //gets strings from sting list
        public static string GetNameFromList(List<string> strList)
        {
            for(int i =0; i < strList.Count; i++)
            {
                 bobTheBuilder.Append(GetPropName(strList, i));
            }
            return bobTheBuilder.ToString();
        }

        //gets individual names from list
        public static string GetPropName(List<string> strList, int numb)
        {
            return strList[numb];
        }
        
        // gets value from property
        public static string GetPropertyValue(object obj, string property)
        {
            return obj.GetType().GetProperty(property).GetValue(obj, null).ToString();
        }
    }
}