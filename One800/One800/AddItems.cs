using System;
using System.Collections.Generic;
using System.Text;
using One800.CrossCutting;

namespace One800
{
    /// <summary>
    /// This class is used to add items to list
    /// </summary>
    public class AddItems
    {
        List<string> lstOutput = new List<string>();
        /// <summary>
        /// Add items to string
        /// </summary>
        /// <param name="StringtoAdd"></param>
        /// <param name="RepeationTimes"></param>
        /// <returns></returns>
        public List<string> Add(string StringtoAdd, int RepeationTimes)
        {
            Logger.RecordMessage("Entering  AddItems.Add", Log.MessageType.Information, Logger.LogTypes.File);
            foreach (char c in StringtoAdd)
            {
                lstOutput = Add(c, RepeationTimes);  //Process First Row
            }
            Logger.RecordMessage("Exiting  AddItems.Add", Log.MessageType.Information, Logger.LogTypes.File);

            return lstOutput;
        }

        /// <summary>
        /// add the character number of time mentioned
        /// </summary>
        /// <param name="letter"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        List<string> Add(char letter, int count)
        {
            Logger.RecordMessage("Entering Private AddItems.Add", Log.MessageType.Information, Logger.LogTypes.File);
            for (int counter = 0; counter < count; counter++)
            {
                lstOutput.Add(letter.ToString());
            }
            Logger.RecordMessage("Exiting private AddItems.Add", Log.MessageType.Information, Logger.LogTypes.File);

            return lstOutput;
        }
    }
}
