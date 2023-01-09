///-----------------------------------------------------------------
///   Namespace:      SDiStudentApi.Repository
///   Author:         Raymond Nnodim
///   Date:           9/17/2017
///   Class:          StudentsRepository
///-----------------------------------------------------------------

using SDiStudentApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDiStudentApi.Repository
{
    /// <summary>
    /// Class to encapsulate a repository of students - in memory repository used
    /// in form of List of students
    /// </summary>
    public class StudentsRepository
    {
        static List<Student> students = new List<Student>();
        private static int Id = 1;

        public static void AddOrUpdateStudent(Student student)
        {
            if (student.ID == 0)
            {
                student.ID = Id++;
                students.Add(student);
            }
            else
            {
                UpdateStudent(student);
            }
        }

        public static void UpdateStudent(Student student)
        {
            int id = student.ID;
            Student stu = students.Where(stud => stud.ID == id).FirstOrDefault();
            if (stu != null)
            {
                stu.Firstname = student.Firstname;
                stu.Lastname = student.Lastname;
                stu.DateOfBirth = student.DateOfBirth;
                stu.GPA = student.GPA;
            }
        }

        public static List<Student> Students
        {
            get
            {
                return students;
            }
        }
    }
}