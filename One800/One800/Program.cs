using System;
using System.Collections.Generic;
using One800.CrossCutting;
using System.Configuration;

namespace One800
{
    /// <summary>
    /// Main Entry point
    /// </summary>
    class Program
    {
        private static void Main(string[] args)
        {
            Logger.RecordMessage("Program Started", Log.MessageType.Information, Logger.LogTypes.File);
            try
            {
                //Display message based on input
                string inputDisplayString = ConfigurationManager.AppSettings["InputType"] == "0" ?"Input Number: " : "Input File Name (Absolute Path): ";
                Console.Write(inputDisplayString);
                string input = Console.ReadLine();
                One800Process one800 = new One800Process();
                one800.ProcessInput(input);
            }
            catch(Exception ex)
            {
                Logger.RecordMessage(ex, Log.MessageType.Information, Logger.LogTypes.File);
            }

            Logger.RecordMessage("Program execution completed", Log.MessageType.Information, Logger.LogTypes.File);

        }
    }
}
