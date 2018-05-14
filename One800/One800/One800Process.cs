using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using One800.CrossCutting;
using One800.Input;
using One800.Output;
using One800.Process;

namespace One800
{
    /// <summary>
    /// THis class is sued to call input and output details
    /// </summary>
    public class One800Process
    {
        /// <summary>
        /// Process Input
        /// </summary>
        /// <param name="digits"></param>
        public void ProcessInput(string digits)
        {
            Logger.RecordMessage("Entering One800Process.ProcessInput", Log.MessageType.Information, Logger.LogTypes.File);

            Input.Input ip = null;

            if (ConfigurationManager.AppSettings["InputType"] == "0")
            {
                ip = new Input.Input(new ConsoleInput())   //Instantiate ConsoleInput
                {
                    InputDigits = digits
                };
            }
            else
            {
                ip = new Input.Input(new FileInput())  //Instantiate FileInput
                {
                    InputDigits = digits
                };
            }
            ip.ProcessInput();
            Logger.RecordMessage("Exiting from One800Process.ProcessInput", Log.MessageType.Information, Logger.LogTypes.File);
        }


        /// <summary>
        /// Process Output
        /// </summary>
        /// <param name="ToOutput"></param>
        public void ProcessOutput(List<string> ToOutput)
        {
            Logger.RecordMessage("Entering One800Process.ProcessOutput", Log.MessageType.Information, Logger.LogTypes.File);

            One800.Output.Output op = null;
            if (ConfigurationManager.AppSettings["OutputType"] == "0") //Console
            {
                op = new One800.Output.Output(new ConsoleDisplay())
                {
                    Data = ToOutput
                };
            }
            else
            {
                op = new One800.Output.Output(new FileOutput())  //File
                {
                    Data = ToOutput
                };

            }
            op.ProcessOutput();
            Logger.RecordMessage("Exiting from One800Process.ProcessOutput", Log.MessageType.Information, Logger.LogTypes.File);

        }

    }
}