using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using One800.CrossCutting;
using One800.Process;

namespace One800.Input
{
    /// <summary>
    /// This class is used to retrieve input from File location provided
    /// </summary>
    public class FileInput : IInputType
    {
        /// <summary>
        /// Process every row in the file
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        List<string> ProcessEachRow(string digits)
        {
            Logger.RecordMessage("Entering  ConsoleInput.ProcessEachRow", Log.MessageType.Information, Logger.LogTypes.File);

            ProcessManager pm = new ProcessManager();
            List<string> data = pm.ProcessDigits(digits);
            Logger.RecordMessage("Exiting  ConsoleInput.Process", Log.MessageType.Information, Logger.LogTypes.File);

            return data;
        }
        /// <summary>
        /// Method to be overridden, read the fileName
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public List<string> Process(string FileName)
        {
            Logger.RecordMessage("Entering  ConsoleInput.ProcessEachRow", Log.MessageType.Information, Logger.LogTypes.File);
            //read the file
            var v2 = (from line in File.ReadAllLines(FileName)
                      select line).ToList<string>();
           
            ProcessManager pm = new ProcessManager();
            List<string> globalList = new List<string>();
            
            foreach (string digits in v2)
            {
                globalList.AddRange(ProcessEachRow(digits));      //Union the result          
            }

            
            Logger.RecordMessage("Exiting  ConsoleInput.ProcessEachRow", Log.MessageType.Information, Logger.LogTypes.File);

            return globalList;
        }

    }
}
