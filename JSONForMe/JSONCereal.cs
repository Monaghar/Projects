using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace JSONForMe
{
    public static class JSONCereal
    {
        public static StringBuilder bobTheBuilder = new StringBuilder();

        //gets the name of an object
        public static string GetObjectName<T>()
        {
            return typeof(T).Name;
        }

        //gets the properties of an object into an IEnumerable
        public static IEnumerable<PropertyInfo> GetPropertyInfo<T>()
        {
            return typeof(T).GetProperties();
        }

        //gets the properties of an object that are not enumerable
        public static IEnumerable<PropertyInfo> GetPropertyInfoA(object obj)
        {
            return obj.GetType().GetProperties();
        }

        // gets value from property
        public static string GetPropertyValue(object obj, PropertyInfo property)
        {
            return property.GetValue(obj, null).ToString();
        }

        public static string GetStringfromPropList(object obj, PropertyInfo property)
        {
            StringBuilder temp = new StringBuilder();
            foreach (PropertyInfo thing in JSONCereal.GetPropertyInfoA(obj))
            {
                temp.Append(JSONCereal.GetPropertyValue(obj, thing));
            }
            return temp.ToString();
        }

        public static string GetStringfromIENUM(object obj, IEnumerable property)
        {
            foreach (PropertyInfo thing in property)
            {
                bobTheBuilder.Append(JSONCereal.GetPropertyValue(obj, thing));
            }
            return "wtf is life";
        }

        //find out if a property is IEnumerable
        public static bool IsPropIenum(object obj, PropertyInfo property)
        {
            return (property.PropertyType.GetInterfaces().Contains(typeof(ICollection)));
        }

        //gets the object name
        //public static string GetObjectName(object obj)
        //{
        //    return obj.GetType().Name;
        //}

        //gets the properties of an object into a string list
        //public static List<PropertyInfo> GetProps(object obj)
        //{
        //    List<PropertyInfo> tempPropList = new List<PropertyInfo>();
        //    foreach (var thing in obj.GetType().GetProperties())
        //    {
        //        tempPropList.Add(thing);
        //    }
        //    return tempPropList;
        //}

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