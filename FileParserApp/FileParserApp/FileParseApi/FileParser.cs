using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileParseApi
{
    public class FileParser
    {
        static Dictionary<string, string> inputsDiction = new Dictionary<string, string>();
        static List<MedReport> processedReports = new List<MedReport>();
        /// <summary>
        /// Driver method - called by Main method to read args from console and process reports
        /// </summary>
        /// <param name="args"></param>
        public static void ParseArgs(string[] args, bool printConsole = true)
        {
            // initalizing keys
            inputsDiction["file"] = "";
            inputsDiction["sort"] = "";
            inputsDiction["search"] = "";
            for (int i = 0; i < args.Length - 1; i += 2)
            {
                inputsDiction[args[i].Substring(1)] = args[i + 1];
            }

            ProcessQuery(inputsDiction["file"], inputsDiction["sort"], inputsDiction["search"], printConsole);
        }

        /// <summary>
        /// Process a file containing one or more reports based on arguments passed to console in args
        /// Uses reflection to achieve dynamic attribute mapping
        /// </summary>
        /// <param name="path"></param>
        /// <param name="sort"></param>
        /// <param name="search"></param>
        public static void ProcessQuery(string path, string sort, string search, bool printConsole = true)
        {
            MedReport report = new MedReport(sort);
            AttributeMapper.MapAttributes(report);
            List<MedReport> reports = new List<MedReport>();
            PropertyInfo[] props = report.GetType().GetProperties();

            

            string line = "";
            using (StreamReader reader = new StreamReader(path))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    try
                    {
                        if (string.IsNullOrEmpty(line.Trim()))
                        {
                            continue;
                        }
                        if (line.Contains("END OF RESULT"))
                        {
                            reports.Add(report);
                            report = new MedReport(sort);
                            continue;
                        }
                        int splitIndex = line.IndexOf(':');
                        string prop = line.Substring(0, splitIndex).ToLower();
                        object val = line.Substring(splitIndex + 1).Trim();

                        var contentProp = props.Where(p => p.Name == AttributeMapper.GetAttribute(prop));

                        if (contentProp.FirstOrDefault() != null)
                        {
                            PropertyInfo propInfo = report.GetType().GetProperty(AttributeMapper.GetAttribute(prop));
                            SetPropValue(report, propInfo, val);
                        }
                        else
                        {
                            report.AddFieldValue(prop, val.ToString());
                        }

                    }
                    catch (Exception ex)
                    {

                    }

                }
            }

            if (!string.IsNullOrEmpty(search))
            {
                reports = (List<MedReport>)ReportSearcher.ObtainSearchReport(reports, search);
            }
            if (!string.IsNullOrEmpty(sort))
            {
                reports.Sort();
            }

            processedReports = reports;
            if(printConsole)
            ReportPrinter.PrintMedReports(reports);
        }

        private static void SetPropValue(MedReport report, PropertyInfo propInfo, object val)
        {
            string propType = propInfo.PropertyType.Name;

            switch (propType)
            {
                case "String":
                    propInfo.SetValue(report, (string)val);
                    break;
                case "Int32":
                    propInfo.SetValue(report, Int32.Parse((string)val));
                    break;
                case "DateTime":
                    propInfo.SetValue(report, DateTime.Parse((string)val));
                    break;
            }
        }


        public static List<MedReport> ProcessedReports
        {
            get
            {
                return processedReports;
            }
        }
    }
}
