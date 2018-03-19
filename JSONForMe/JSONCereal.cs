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

        public static string PrintToString<T>(T Pupper)
        {
            StringBuilder bobTheBuilder = new StringBuilder();
            bobTheBuilder.Append("{");
            bobTheBuilder.Append("\""+typeof(T).Name+"\":");
            bobTheBuilder.Append("{");
            foreach (PropertyInfo thing in JSONCereal.GetPropertyInfo<T>())
            {
                bobTheBuilder.Append("\""+thing.Name+"\":");
                if (!(JSONCereal.IsPropIenum(thing)))
                {
                    try
                    {
                        int intTest = (int)thing.GetValue(Pupper, null);
                        bobTheBuilder.Append((intTest).ToString()+',');
                    }
                    catch
                    {
                        bobTheBuilder.Append("\""+thing.GetValue(Pupper, null).ToString()+"\",");
                    }
                }
                else
                {
                    bobTheBuilder.Append("[");
                    foreach (string thiing in thing.GetValue(Pupper, null) as IList)
                    { 
                        try
                        {
                            int intTest = Convert.ToInt32(thiing);
                            bobTheBuilder.Append(intTest).ToString();
                        }
                        catch
                        {
                            bobTheBuilder.Append("\"" + thiing.ToString() + "\",");
                        }
                    }
                    bobTheBuilder.Append("]");
                }
            }
            bobTheBuilder.Append("}}");
            return bobTheBuilder.ToString();
        }

        public static string AddQuotes(string input)
        { 
            return "\"" + input + "\"";
        }

        public static string AddColon(string input)
        {
            return input + ":";
        }

        //gets the properties of an object into an IEnumerable
        public static IEnumerable<PropertyInfo> GetPropertyInfo<T>()
        {
            return typeof(T).GetProperties();
        }

        //find out if a property is IEnumerable
        public static bool IsPropIenum(PropertyInfo property)
        {
            return (property.PropertyType.GetInterfaces().Contains(typeof(ICollection)));
        }

        //gets the name of an object
        //public static string GetObjectName<T>()
        //{
        //    return typeof(T).Name;
        //}

        // gets value from property
        //public static string GetPropertyValue(object obj, PropertyInfo property)
        //{
        //    return property.GetValue(obj, null).ToString();
        //}

        //public static string GetStringfromPropList(object obj, PropertyInfo property)
        //{
        //    StringBuilder temp = new StringBuilder();
        //    foreach (PropertyInfo thing in JSONCereal.GetPropertyInfo<object>())
        //    {
        //        temp.Append(thing.GetValue(obj, null));
        //    }
        //    return temp.ToString();
        //}

        //gets the properties of an object that are not enumerable
        //public static IEnumerable<PropertyInfo> GetPropertyInfoA(object obj)
        //{
        //    return obj.GetType().GetProperties();
        //}

        //gets the object name
        //public static string GetObjectName(object obj)
        //{
        //    return obj.GetType().Name;
        //}

        //public static string GetStringfromIENUM(object obj, IEnumerable property)
        //{
        //    foreach (PropertyInfo thing in property)
        //    {
        //        bobTheBuilder.Append(thing.GetValue(obj, null));
        //    }
        //    return "wtf is life";
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