using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test.Data.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        public string StudentIdCard { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Year { get; set; }

        [Required]
        public int StudentStatusId { get; set; }
    }
}