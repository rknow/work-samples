///-----------------------------------------------------------------
///   Namespace:      SDiFileParser
///   Author:         Raymond Nnodim
///   Date:           9/17/2017
///   Class:          ReportPrinter
///-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParseApi
{
    /// <summary>
    /// Class encapsulated for printing report
    /// </summary>
    public class ReportPrinter
    {

        public static void PrintMedReport(MedReport report)
        {
            Console.Write(report);
        }

        public static void PrintMedReports(IEnumerable<MedReport> reports)
        {
            foreach(MedReport report in reports)
            {
                PrintMedReport(report);
            }
            if(reports.Count() == 0)
            {
                Console.WriteLine("There are no reports to print");
            }
        }
    }
}
