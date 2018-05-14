using System;
using System.Collections.Generic;
using System.Text;
using One800.CrossCutting;

namespace One800
{
    /// <summary>
    /// This class is usedto append items
    /// </summary>
    public class AppendItems
    {
        /// <summary>
        /// Append items to list
        /// </summary>
        /// <param name="input"></param>
        /// <param name="ToList"></param>
        /// <returns></returns>
        public List<String> Append(string input, List<string> ToList)
        {
            Logger.RecordMessage("Entering AppendItems.Append", Log.MessageType.Information, Logger.LogTypes.File);

            for (int i = 0; i < ToList.Count; i++)
            {
                foreach (char c in input)
                {
                    ToList[i] = ToList[i] + c;
                    i++;
                }
                i--; // Reduce the i count because it goes one extra in above loop
            }
            Logger.RecordMessage("Exiting AppendItems.Append", Log.MessageType.Information, Logger.LogTypes.File);
            return ToList;
        }
    }
}
