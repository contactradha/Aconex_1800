using System;
using System.Collections.Generic;
using System.Text;

namespace One800.Output
{
    /// <summary>
    /// Output Concrete class
    /// </summary>
    public class Output
    {
        private IOutputType OutputType { get; set; }
        public List<string> Data { get; set; }
        public Output(IOutputType type)
        {
            this.OutputType = type;
        }

        /// <summary>
        /// Method used to process data on different outputs
        /// </summary>
        public void ProcessOutput()
        {
            this.OutputType.DiplayData(this);
        }
    }
}