using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Test.Data;
using Test.Data.Models;
using Test.Services;

namespace Test.Controllers
{
    public class CoursesController : ApiController
    {
        CourseService courses = new CourseService(new TestContext());

        //GET: api/courses
        public List<Course> GetCourses()
        {
            return courses.GetAllCourses();
        }



        // POST api/courses
        public void Post([FromBody] Course course)
        {
            courses.CreateCourse(course);
        }
    }
}