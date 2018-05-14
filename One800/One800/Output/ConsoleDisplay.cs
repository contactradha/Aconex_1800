using System;
using System.Collections.Generic;
using System.Text;
using One800.CrossCutting;

namespace One800.Output
{
    /// <summary>
    /// To display data on console
    /// </summary>
    public class ConsoleDisplay : IOutputType
    {
        /// <summary>
        /// Display data on console
        /// </summary>
        /// <param name="Data"></param>
        public void DiplayData(string Data)
        {
            Logger.RecordMessage("Entering  ConsoleDisplay.DisplayData", Log.MessageType.Information, Logger.LogTypes.File);

            Console.WriteLine(Data);
            Logger.RecordMessage("Entering  ConsoleDisplay.DisplayData", Log.MessageType.Information, Logger.LogTypes.File);

        }

        /// <summary>
        /// Display data console
        /// </summary>
        /// <param name="output"></param>
        public void DiplayData(Output output)
        {
            Logger.RecordMessage("Entering  ConsoleDisplay.DisplayData", Log.MessageType.Information, Logger.LogTypes.File);

            List<string> OutputInfo = output.Data;
            OutputInfo.ForEach(Console.WriteLine);
            Logger.RecordMessage("Entering  ConsoleDisplay.DisplayData", Log.MessageType.Information, Logger.LogTypes.File);

            Console.ReadKey();
        }
    }
}
