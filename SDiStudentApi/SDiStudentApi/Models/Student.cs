using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDiStudentApi.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string DateOfBirth { get; set; }
        public double GPA { get; set; }
    }
}