using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using One800.CrossCutting;
using System.Configuration;

namespace One800
{
    /// <summary>
    /// this class is used to display configure items
    /// </summary>
    public class Configure
    {
        /// <summary>
        /// Set Dictionary
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> SetDictionary()
        {
            Logger.RecordMessage("Entering Configure.SetDictionary", Log.MessageType.Information, Logger.LogTypes.File);


            Dictionary<string, string> dict = new Dictionary<string, string>();

            //string FilePath = "C:\\RK\\Labs\\Aconex\\Assignments\\One800\\One800\\One800\\Dictionary.txt";
            string FilePath = ConfigurationManager.AppSettings["DictionaryPath"];

            var v2 = (from line in File.ReadAllLines(FilePath)
                      let values = line.Split('\t')
                      select new { Key = values[0], Value = values[1] }).ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, string> pair in v2)
            {
                dict.Add(pair.Key, pair.Value);
            }
            Logger.RecordMessage("Exiting Configure.SetDictionary", Log.MessageType.Information, Logger.LogTypes.File);

            return dict;
        }
    }
}
