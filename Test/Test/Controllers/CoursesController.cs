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
        CourseService course = new CourseService(new TestContext());

        //GET: api/courses
        public List<Course> GetCourses()
        {
            return course.GetAllCourses();
        }

        // GET api/courses/5
        public List<Student> Get(int id)
        {
            return course.GetStudentsByCourseId(id);
        }

        // POST api/courses
        public void Post([FromBody] Course c)
        {
            course.CreateCourse(c);
        }
    }
}