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

        //GET: api/Courses
        public List<Course> GetCourses()
        {
            return courses.GetAllCourses();
        }

        //// POST: api/Courses
        //[ResponseType(typeof(Course))]
        //public IHttpActionResult PostCourse(Course course)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Courses.Add(course);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = course.Id }, course);
        //}


    }
}