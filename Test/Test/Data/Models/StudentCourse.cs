using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Data.Models
{
    public class StudentCourse
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
    }
}