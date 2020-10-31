using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParseApi
{
    public class ParseUtils
    {

        public static string[] GenerateArgsArr(string format)
        {
            return (format.Replace("Program.exe", "").Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
        }

        public static string GenerateReport(List<MedReport> reports)
        {
            StringBuilder builder = new StringBuilder();

            foreach(MedReport report in reports)
            {
                builder.Append(report.ToString());
                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }
    }
}
