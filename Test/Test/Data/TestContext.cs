using Test.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Test.Data
{
    public class TestContext : DbContext
    {
        public TestContext() : base("name=TestContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentStatus> StudentStatus { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> CoursesOfStudents { get; set; }
    }
}
