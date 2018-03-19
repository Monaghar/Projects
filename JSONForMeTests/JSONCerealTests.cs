using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSONForMe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;

namespace JSONForMe.Tests
{
    [TestClass()]
    public class JSONCerealTests
    {
        private string testString = "this is for testing";
        private Dog testPupper = new Dog() { name = "Woofer", legs = 4, spots = new List<string>() { "L", "O", "3" } };

        [TestMethod()]
        public void PrintToStringTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddQuotesTest()
        {
            Assert.AreEqual(JSONCereal.AddQuotes(testString), "\""+testString+"\"");
        }

        [TestMethod()]
        public void AddColonTest()
        {
            Assert.AreEqual(JSONCereal.AddColon(testString), testString + ":");
        }
        //seperate the testing of each property
        [TestMethod()]
        public void GetPropertyInfoTest()
        {
            IEnumerable<PropertyInfo> testProp = typeof(Dog).GetProperties();
            foreach (var testThing in testProp)
            {
                Assert.IsTrue(testThing is PropertyInfo);
            }
        }
        //seperate the testing of each property
        [TestMethod()]
        public void IsPropIenumTest()
        {
            IEnumerable<PropertyInfo> testProp = typeof(Dog).GetProperties();
            for(int i = 0; i < testProp.Count(); i++)
            {
                var tempVal = testProp.ElementAt(i);
                if(tempVal is ICollection)
                {
                    Assert.IsTrue(true);
                }
            }
        }
    }
}