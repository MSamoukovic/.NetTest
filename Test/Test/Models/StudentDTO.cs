using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Test.Data.Models;

namespace Test.Models
{
    public class StudentDTO
    {
        public int Id { get; set; }

        [Required]
        public string StudentIdCard { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Year { get; set; }

        [Required]
        public string StudentStatus { get; set; }

        public List<string> CoursesList { get; set; }
    }
}