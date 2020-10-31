///-----------------------------------------------------------------
///   Namespace:      SDiFileParser
///   Author:         Raymond Nnodim
///   Date:           9/17/2017
///   Class:          AttributeMapper
///-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace FileParseApi
{
    /// <summary>
    /// class for helping with mapping attribute names with Property names for aid reflection calls on those Properties
    /// </summary>
    class AttributeMapper
    {
        static Dictionary<string, string> attrMapper = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

        public static void AddAttribute(string name, string propName)
        {
            name = name.Replace(" ", "");
            attrMapper[name] = propName;
        }

        public static string GetAttribute(string name)
        {
            name = name.Replace(" ", "").ToLower();
            string result = attrMapper.ContainsKey(name) ? attrMapper[name] : string.Empty;
            return result;
        }

        /// <summary>
        /// Used to map attribute to Property names of a report class
        /// </summary>
        /// <param name="report"></param>
        public static void MapAttributes(MedReport report)
        {
            PropertyInfo[] props = report.GetType().GetProperties();

            foreach(PropertyInfo prop in props)
            {
                string name = prop.Name;
                AddAttribute(name.Replace(" ", "").ToLower(), name);
            }
        }
    }
}
