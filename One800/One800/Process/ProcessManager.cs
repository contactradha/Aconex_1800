using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using One800.CrossCutting;

namespace One800.Process
{
    /// <summary>
    /// THis class will be called by input to process input and output
    /// </summary>
    public class ProcessManager
    {
        List<string> lstOutput = new List<string>();
        string RemainingInputToProcess = "";

        /// <summary>
        /// Process input digits
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<string> ProcessDigits(string input)
        {
            Logger.RecordMessage("Entering  ProcessManager.ProcessDigits", Log.MessageType.Information, Logger.LogTypes.File);

            int cntDigit = 0;
            foreach (char digit in input)
            {
                if (Configure.SetDictionary().Keys.Contains(digit.ToString()))
                {
                    RemainingInputToProcess = input.Substring(cntDigit);  //get remaining inputs
                    ProcessEachDigit(digit, cntDigit);
                    lstOutput.Sort(); //Sort the list, so that other iteration covers all
                    cntDigit++; //This increment is required to find substring
                }
            }
            Logger.RecordMessage("Exiting  ProcessManager.ProcessDigits", Log.MessageType.Information, Logger.LogTypes.File);

            return lstOutput;
        }

        /// <summary>
        /// Process every digit of the string
        /// </summary>
        /// <param name="InputChar"></param>
        /// <param name="StringStartPoint"></param>
        void ProcessEachDigit(char InputChar, int StringStartPoint)
        {
            Logger.RecordMessage("Entering  ProcessManager.ProcessEachDigit", Log.MessageType.Information, Logger.LogTypes.File);

            int totalIterations = getTotalIterations(RemainingInputToProcess); //Identify remaining strings
            string digitDictVal = Configure.SetDictionary()[InputChar.ToString()]; //Get number of chars
            int repetitionTimes = totalIterations / digitDictVal.Length;
            AddItems AddItemsToList = new AddItems();
            AppendItems AppendItemsToList = new AppendItems();
            lstOutput = StringStartPoint == 0 ? AddItemsToList.Add(digitDictVal, repetitionTimes) : AppendItemsToList.Append(digitDictVal, lstOutput);
            Logger.RecordMessage("Exiting  ProcessManager.ProcessEachDigit", Log.MessageType.Information, Logger.LogTypes.File);

        }

        /// <summary>
        /// Get total iterations for given input
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        int getTotalIterations(string input)
        {
            Logger.RecordMessage("Entering  ProcessManager.getTotalIterations", Log.MessageType.Information, Logger.LogTypes.File);

            int iterations = 1;
            foreach (char c in input) //loop through each character
            {
                if (Configure.SetDictionary().Keys.Contains(c.ToString()))
                {
                    iterations = iterations * Configure.SetDictionary()[c.ToString()].Length;
                }
            }
            Logger.RecordMessage("Exiting  ProcessManager.getTotalIterations", Log.MessageType.Information, Logger.LogTypes.File);

            return iterations;
        }
    }
}

