using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class DictionaryUtilities
    {
        internal static Dictionary<string, string[]> createFullDictionary(Dictionary<string, string[]> i_Dictionary1, Dictionary<string, string[]> i_Dictionary2, Dictionary<string, string[]> i_Dictionary3)
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
            foreach (KeyValuePair<string, string[]> item in i_Dictionary3)
            {
                combinedDict[item.Key] = item.Value;
            }
          
            return combinedDict;
        }
    }
}
