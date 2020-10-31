///-----------------------------------------------------------------
///   Namespace:      SDiFileParser
///   Author:         Raymond Nnodim
///   Date:           9/17/2017
///   Class:          ReportSearcher
///-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FileParseApi
{
    /// <summary>
    /// class encapsulated for searching reports
    /// </summary>
    public class ReportSearcher
    {
        /// <summary>
        /// Searches a particular report fields for a search term - used as a predicate,
        /// search is case-insensitive
        /// </summary>
        /// <param name="report"></param>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public static bool ContainsTerm(MedReport report, string searchTerm)
        {
            PropertyInfo[] terms =  report.GetType().GetProperties(); 
            PropertyInfo info =  terms.FirstOrDefault(e => 
                                    ((e.GetValue(report,null) != null) && (e.Name != MedReport.CompareFieldName) &&
                                    ((string)e.GetValue(report, null).ToString().ToLower()).Contains(searchTerm.ToLower())));
            bool additionalSearch = report.ContainsValue(searchTerm);

            return info != null || additionalSearch;
        }

        /// <summary>
        /// Searches an ienumerable of reports for a search term -- uses ContainsTerm as a predicate
        /// </summary>
        /// <param name="reports"></param>
        /// <param name="searchTerm"></param>
        /// <returns></returns>
        public static IEnumerable<MedReport> ObtainSearchReport(IEnumerable<MedReport> reports, string searchTerm)
        {
            if(string.IsNullOrEmpty(searchTerm))
            {
                return reports;
            }
            return Enumerable.Where(reports, report => ContainsTerm(report, searchTerm)).ToList<MedReport>(); 
        }
    }
}
