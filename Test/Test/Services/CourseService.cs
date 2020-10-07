using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Data;
using Test.Data.Models;
using Test.Services.Interface;

namespace Test.Services
{
    public class CourseService : Service, ICourseService
    {
        public CourseService(TestContext context) : base(context)
        {
        }
        public List<Course> GetAllCourses()
        {
            return Context.Courses.ToList();
        }

        public void CreateCourse(Course course)
        {
            Context.Courses.Add(course);
            Context.SaveChanges();
        }
    }
}