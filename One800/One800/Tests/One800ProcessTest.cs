using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace One800.Tests
{
    [TestFixture]
    public class One800ProcessTest
    {
        List<string> lstOutput = new List<string>();
        [TestCase("23", ExpectedResult = 6)]
        [TestCase("237", ExpectedResult = 36)]
        public int getTotalIterations(string input)
        {
            int iterations = 1;
            foreach (char c in input)
            {
                if (Configure.SetDictionary().Keys.Contains(c.ToString()))
                {
                    iterations = iterations * Configure.SetDictionary()[c.ToString()].Length;
                }
            }
            return iterations;
        }


        [TestCase( '2',0,"234", ExpectedResult=27)]  
        [TestCase('2', 0, "2347", ExpectedResult = 100)] //Failed
        [TestCase('2', 0, "237", ExpectedResult = 36)]
        [TestCase('2', 0, "23.7", ExpectedResult = 36)]
       
        public int ProcessEachDigitToAdd(char InputChar, int StringStartPoint,string input)
        {
            lstOutput = new List<string>();
            int totalIterations = getTotalIterations(input); //Identify remaining strings
            string digitDictVal = Configure.SetDictionary()[InputChar.ToString()]; //Get number of chars
            int repetitionTimes = totalIterations / digitDictVal.Length;            
            lstOutput = Add(digitDictVal, repetitionTimes);

            return lstOutput.Count;

        }


        List<string> Add(string StringtoAdd, int RepeationTimes)
        {
            foreach (char c in StringtoAdd)
            {
                lstOutput = Add(c, RepeationTimes);  //Process First Row
            }
            return lstOutput;
        }

        List<string> Add(char letter, int count)
        {
            for (int counter = 0; counter < count; counter++)
            {
                lstOutput.Add(letter.ToString());
            }

            return lstOutput;
        }
        
    }
}
