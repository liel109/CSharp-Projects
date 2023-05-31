using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class DictionaryUtilities
    {
        internal static Dictionary<string, string[]> createFullDictionary(Dictionary<string, string[]> i_Dictionary1, Dictionary<string, string[]> i_Dictionary2, bool i_IsPetrolEngine)
        {
            Dictionary<string, string[]> combinedDict = new Dictionary<string, string[]>();

            foreach (KeyValuePair<string, string[]> item in i_Dictionary1)
            {
                combinedDict[item.Key] = item.Value;
            }
            foreach (KeyValuePair<string, string[]> item in i_Dictionary2)
            {
                combinedDict[item.Key] = item.Value;
            }
            if (i_IsPetrolEngine)
            {
                combinedDict["Fuel Amount"] =  null;
            }
            else
            {
                combinedDict["Remaining Battery Hours"] = null;
            }

            return combinedDict;
        }
    }
}
