using System;
using System.Collections.Generic;
using System.IO;
using One800.CrossCutting;
using System.Configuration; 
namespace One800.Output
{
    /// <summary>
    /// Store data in File
    /// </summary>
    public class FileOutput : IOutputType
    {
        /// <summary>
        /// Display data on file
        /// </summary>
        /// <param name="output"></param>

        public void DiplayData(Output output)
        {
            Logger.RecordMessage("Entering  FileOutput.DisplayData", Log.MessageType.Information, Logger.LogTypes.File);

            List<string> OutputInfo = output.Data;
            String FileName = ConfigurationManager.AppSettings["OutputFilePath"];
            FileStream fileStream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fileStream);
            // Set the file pointer to the end of the file
            writer.BaseStream.Seek(0, SeekOrigin.End);
            OutputInfo.ForEach(writer.WriteLine);
            writer.Flush();
            writer.Close();
            Console.WriteLine("The File is generated Successfully at {0}", FileName);
            Logger.RecordMessage("Exiting  FileOutput.DisplayData", Log.MessageType.Information, Logger.LogTypes.File);
            Console.ReadKey();
        }
    }
}