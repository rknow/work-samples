///-----------------------------------------------------------------
///   Namespace:      SDiStudentApi.Controllers
///   Author:         Raymond Nnodim
///   Date:           9/17/2017
///   Class:          StudentsController
///-----------------------------------------------------------------

using SDiStudentApi.Models;
using SDiStudentApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SDiStudentApi.Controllers
{
    public class StudentsController : ApiController
    {
        public IEnumerable<Student> Get()
        {
            return StudentsRepository.Students;
        }

        public Student Get(string firstname, string lastname)
        {
            return StudentsRepository.Students.FirstOrDefault(e => e.Firstname == firstname && e.Lastname == lastname);
        }

        public Student Get(int id)
        {
            return StudentsRepository.Students.FirstOrDefault(e => e.ID == id);
        }

        public void Post([FromBody] Student student)
        {
            StudentsRepository.AddOrUpdateStudent(student);
        }

        

    }
}
