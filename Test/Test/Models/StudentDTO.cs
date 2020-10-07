using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Data.Models;

namespace Test.Models
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string StudentIdCard { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Year { get; set; }
        public string StudentStatus { get; set; }
        public List<string> CoursesList { get; set; }

    }
}