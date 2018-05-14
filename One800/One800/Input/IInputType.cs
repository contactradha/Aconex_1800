using System;
using System.Collections.Generic;
using System.Text;

namespace One800.Input
{
    /// <summary>
    /// abstract class to be implemented by different inputs
    /// </summary>
    public interface IInputType
    {
        List<string> Process(string input);
    }
}
