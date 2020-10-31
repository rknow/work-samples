using System;
using System.Collections.Generic;
using System.Linq;
///-----------------------------------------------------------------
///   Namespace:      SDiFileParser
///   Author:         Raymond Nnodim
///   Date:           9/17/2017
///   Class:          MedReport
///-----------------------------------------------------------------

using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace FileParseApi
{
    /// <summary>
    /// Class encapsulated for storing each report read, inherits from IComparable interface for
    /// easier and more customized reporting. Uses reflection to achieve dynamic comparison
    /// </summary>
    public class MedReport : IComparable
    {
        public static readonly string CompareFieldName = "CompareField";
        private string compareField = "";

        private Dictionary<string, string> additionalFields
                = new System.Collections.Generic.Dictionary<string, string>();
        public MedReport(string compField)
        {
            compareField = compField.Replace(" ", "");
        }

        public MedReport()
        {
        }

        /// <summary>
        /// Add additional field to report
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void AddFieldValue(string key, string value)
        {
            additionalFields[key] = value;
        }

        /// <summary>
        /// Find or return empty string if key is found as additional field
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetFieldValue(string key)
        {
            string result = string.Empty;
            result = additionalFields.ContainsKey(key) ? additionalFields[key] : result;

            return result;
        }

        public bool ContainsValue(string srchTerm)
        {
            bool containsVal = false;

            foreach(KeyValuePair<string, string> kv in additionalFields)
            {
                string val = kv.Value.ToString().ToLower();
                if (val.Contains(srchTerm.ToLower()))
                {
                    containsVal = true;
                    break;
                }
            }
            return containsVal;
        }

        /// <summary>
        /// For comparing types
        /// </summary>
        /// <param name="obj"></param>
        public void TypeTester(object obj)
        {
            MedReport alt = (MedReport)obj;
            object val = this.GetType().GetProperty(this.compareField).GetValue(this, null);
            object val2 = obj.GetType().GetProperty(alt.compareField).GetValue(alt, null);

           CompareHelper(val, val2);
        }
        /// <summary>
        /// Implementation of CompareTo method of IComparable interface
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            object val = null;
            object val2 = null;
            MedReport alt = (MedReport)obj;

            PropertyInfo[] props = this.GetType().GetProperties();

            var contentProp = props.Where(p => p.Name == AttributeMapper.GetAttribute(this.compareField));

            if (contentProp.FirstOrDefault() != null)
            {
                val = this.GetType().GetProperty(AttributeMapper.GetAttribute(this.compareField)).GetValue(this, null);
            }
            val = val == null && additionalFields.ContainsKey(this.compareField) ? additionalFields[this.compareField] : val;

            contentProp = props.Where(p => p.Name == AttributeMapper.GetAttribute(alt.compareField));
            if (contentProp.FirstOrDefault() != null)
            {
                val2 = alt.GetType().GetProperty(AttributeMapper.GetAttribute(alt.compareField)).GetValue(alt, null);
            }         
            val2 = val2 == null && alt.additionalFields.ContainsKey(alt.compareField) ? alt.additionalFields[alt.compareField] : val2;

            val = val == null ? string.Empty : val;
            val2 = val2 == null ? string.Empty : val2;
            return CompareHelper(val, val2);
        }

        /// <summary>
        /// helper method for comparing given possibility of different data times in report
        /// </summary>
        /// <param name="val"></param>
        /// <param name="val2"></param>
        /// <returns></returns>
        private int CompareHelper(object val, object val2)
        {
            string objType = val.GetType().Name;
            int result = 0;
            switch(objType)
            {
                case "String":
                    result = String.Compare((string)val, (string)val2);
                break;
                case "Int32":
                    result = (int)val < (int)val2 ? -1 : (int)val == (int)val2 ? 0 : 1;
                break;
                case "DateTime":
                    result = DateTime.Compare((DateTime)val, (DateTime)val2);
                break;
            }
            return result;
        }

        /// <summary>
        /// the field that forms the basis of sorting this report
        /// </summary>
        public string CompareField
        {
            get { return compareField; }
            internal set { compareField = value; }
        }

        #region MedicalReport Properties

        public int FacilityID { get; set; }
        public string FacilityName { get; set; }
        public string FacilityLocation { get; set; }
        public string Patient { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public int PatientID { get; set; }
        public string Procedure { get; set; }
        public int NumberOfFilms { get; set; }
        public string Laterality { get; set; }
        public string Contrast { get; set; }
        public string Reason { get; set; }
        public DateTime ExamDate { get; set; }
        public string Radiologist { get; set; }
        public string OrderingPh { get; set; }

        public string POS { get; set; }

        public string ReportStatus { get; set; }

        public string AttendingDoctor { get; set; }

        
        public string AdmittingDoctor { get; set; }

        public string DirectorName { get; set; }

        #endregion


        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format("FacilityID: {0}{1}", FacilityID, Environment.NewLine));
            builder.Append(string.Format("FacilityName: {0}{1}", FacilityName, Environment.NewLine));
            builder.Append(string.Format("Facility Location: {0}{1}", FacilityLocation, Environment.NewLine));
            builder.Append(string.Format("Patient: {0}{1}", Patient, Environment.NewLine));
            builder.Append(string.Format("Gender: {0}{1}", Gender, Environment.NewLine));
            builder.Append(string.Format("PatientID: {0}{1}", PatientID, Environment.NewLine));
            builder.Append(string.Format("Procedure: {0}{1}", Procedure, Environment.NewLine));
            builder.Append(string.Format("Number of Films: {0}{1}", NumberOfFilms, Environment.NewLine));
            builder.Append(string.Format("Laterality: {0}{1}", Laterality, Environment.NewLine));
            builder.Append(string.Format("Contrast: {0}{1}", Contrast, Environment.NewLine));
            builder.Append(string.Format("Reason: {0}{1}", Reason, Environment.NewLine));
            builder.Append(string.Format("ExamDate: {0}{1}", ExamDate, Environment.NewLine));
            builder.Append(string.Format("FacilityID: {0}{1}", FacilityID, Environment.NewLine));
            builder.Append(string.Format("Radiologist: {0}{1}", Radiologist, Environment.NewLine));
            builder.Append(string.Format("Ordering Ph: {0}{1}", OrderingPh, Environment.NewLine));
            builder.Append(string.Format("POS: {0}{1}", POS, Environment.NewLine));
            builder.Append(string.Format("ReportStatus: {0}{1}", ReportStatus, Environment.NewLine));

            builder.Append(string.Format("Attending Doctor: {0}{1}", AttendingDoctor, Environment.NewLine));
            builder.Append(string.Format("Admitting Doctor: {0}{1}", AdmittingDoctor, Environment.NewLine));
            builder.Append(string.Format("Director Name: {0}{1}", DirectorName, Environment.NewLine));

            foreach(KeyValuePair<string, string> kv in additionalFields)
            {
                builder.Append(string.Format("{0}: {1}{2}", kv.Key, kv.Value, Environment.NewLine));
            }

            builder.Append(string.Format("\n{0}{1}{2}", "===================END OF RESULT===================",
                                        Environment.NewLine, Environment.NewLine));

            return builder.ToString();
        }

    }
}
