using System;
using System.Collections.Generic;
using System.Text;
using One800.CrossCutting;
using One800.Process;

namespace One800.Input
{
    /// <summary>
    /// This class is used to read content from console
    /// </summary>
    public class ConsoleInput:IInputType
    {
        /// <summary>
        /// Process the input
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public List<string> Process(string digits)
        {
            Logger.RecordMessage("Entering  ConsoleInput.Process", Log.MessageType.Information, Logger.LogTypes.File);

            ProcessManager pm = new ProcessManager();
            List<string> data = pm.ProcessDigits(digits);
            Logger.RecordMessage("Exiting  ConsoleInput.Process", Log.MessageType.Information, Logger.LogTypes.File);

            return data;
        }
    }
}
