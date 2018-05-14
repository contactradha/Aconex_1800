using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.IO;
using System.Linq;
using NUnit.Framework.Internal;

namespace One800.Tests
{
    [TestFixture]
    public class ConfigureTest
    {
        [TestCase ("C:\\RK\\Labs\\Aconex\\Assignments\\One800\\One800\\One800\\Dictionary.txt",ExpectedResult = 9)]
        [TestCase("C:\\RK\\Labs\\Aconex\\Assignments\\One800\\One800\\One800\\Dictionary.txt", ExpectedResult = 8)]
        public int SetDictionary(string FilePath)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            
           var v2 = (from line in File.ReadAllLines(FilePath)
                      let values = line.Split('\t')
                      select new { Key = values[0], Value = values[1] }).ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, string> pair in v2)
            {
                dict.Add(pair.Key, pair.Value);
            }

           
            return dict.Keys.Count;
        }
    }
}
