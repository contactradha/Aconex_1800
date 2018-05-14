using System;
using System.Collections.Generic;
using System.Text;

namespace One800.Input
{
    /// <summary>
    /// Input concrete class to process different products
    /// </summary>
    public class Input
    {
        private IInputType InputType { get; set; }

        public string InputDigits { get; set; }

        public Input(IInputType type)
        {
            this.InputType = type;
        }
        /// <summary>
        /// THis method is used to process different inputs
        /// </summary>
        public void ProcessInput()
        {

            One800Process o8p = new One800Process();
            o8p.ProcessOutput(this.InputType.Process(InputDigits));

        }
    }
}
