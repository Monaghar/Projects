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
        //delte the last comma in a non enum property
        //the else clause at the end pulls thing as a method info? not as the propertytype of thing which should be Puppy, 
        public static string PrintToJSON<T>(T Pupper)
        {
            StringBuilder bobTheBuilder = new StringBuilder();
            bobTheBuilder.Append("{");
            bobTheBuilder.Append(JSONObject(typeof(T).Name));
            foreach (PropertyInfo thing in GetPropertyInfo<T>())
            {
                bobTheBuilder.Append(JSONKey(thing));
                if (IsPropIenum(thing))
                {
                    bobTheBuilder.Append("[");
                    foreach (string thiing in thing.GetValue(Pupper, null) as IList)
                    {
                        bobTheBuilder.Append(JSONTryValue(thiing));
                    }
                    string tempString = TrimItem(bobTheBuilder.ToString());
                    bobTheBuilder.Clear();
                    bobTheBuilder.Append(tempString + "],");
                }
                //if(thing is another type like object, or enum(don't know how json does this) or ect. call print to JSON on it?)
                else if(thing.PropertyType.IsPrimitive)
                {
                    bobTheBuilder.Append(JSONTryValue(thing.GetValue(Pupper, null).ToString()));
                }
                else if(thing.PropertyType == typeof(string))
                {
                    bobTheBuilder.Append(JSONTryValue(thing.GetValue(Pupper, null).ToString()));
                }
                else
                {
                    //var NMI = MethodInfo.MakeGenericMethod(thing.PropertyType);
                    //NMI.Invoke(null, thing.GetValue(Pupper.));
                    //thing.PropertyType.MakeGenericType();
                    // var test = thing.PropertyType;
                    //var typr = (test.GetType());
                    //PrintToJSON(thing.PropertyType);
                }
                TrimItem(bobTheBuilder.ToString());
            }
            TrimItem(bobTheBuilder.ToString());
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

        public static string AddComma(string input)
        {
            return input + ",";
        }

        public static string JSONKey(PropertyInfo input)
        {
            return AddColon(AddQuotes(input.Name));
        }

        public static string JSONObject(string input)
        {
            return AddColon(AddQuotes(input)) + "{";
        }

        public static string JSONValue(string input)
        {
                return AddComma(AddQuotes(input));
        }

        public static string JSONValue(int input)
        {
            return AddComma(input.ToString());
        }

        public static string JSONValue(bool input)
        {
            return AddComma(input.ToString());
        }

        public static string JSONTryValue(string input)
        {
            int intValue;
            bool boolValue;
            if(Int32.TryParse(input, out intValue))
            {
                return (JSONValue(intValue).ToString());
            }
            if (bool.TryParse(input, out boolValue))
            {
                return (JSONValue(boolValue).ToString());
            }
            else
            {
                return (JSONValue(input));
            }
            
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

        public static string TrimItem(string input)
        {
            if (input.EndsWith(","))
            {
                return input.Remove(input.Length - 1, 1);
            }
            return input;
        }

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
    }
}