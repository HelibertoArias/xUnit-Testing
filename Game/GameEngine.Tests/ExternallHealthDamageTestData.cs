using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit.Sdk;

namespace GameEngine.Tests
{
    public class ExternallHealthDamageTestData  
    {
         public static IEnumerable<object[]> TestData
        {
            get
            {
                string[] csvLines = File.ReadAllLines("TestData.csv");

                var testCases = new List<object[]>();

                foreach (var item in csvLines)
                {
                    IEnumerable<int> values = item.Split(',').Select(int.Parse);

                    object[] testCase = values.Cast<object>().ToArray();
                    testCases.Add(testCase);
                }
                return testCases;
            }
        }
    }
}
