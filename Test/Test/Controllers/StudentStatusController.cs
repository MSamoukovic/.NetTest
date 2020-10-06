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
    public class StudentStatusController : ApiController
    {
        StudentStatusService studentStatus = new StudentStatusService(new TestContext());

        // GET: api/StudentStatus
        public List<StudentStatus> GetStudentStatus()
        {
            return studentStatus.GetAllStudentStatus();
        }

        //// GET: api/StudentStatus/5
        //[ResponseType(typeof(StudentStatus))]
        //public IHttpActionResult GetStudentStatus(int id)
        //{
        //    StudentStatus studentStatus = db.StudentStatus.Find(id);
        //    if (studentStatus == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(studentStatus);
        //}

        //// PUT: api/StudentStatus/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutStudentStatus(int id, StudentStatus studentStatus)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != studentStatus.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(studentStatus).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StudentStatusExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/StudentStatus
        //[ResponseType(typeof(StudentStatus))]
        //public IHttpActionResult PostStudentStatus(StudentStatus studentStatus)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.StudentStatus.Add(studentStatus);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = studentStatus.Id }, studentStatus);
        //}

        //// DELETE: api/StudentStatus/5
        //[ResponseType(typeof(StudentStatus))]
        //public IHttpActionResult DeleteStudentStatus(int id)
        //{
        //    StudentStatus studentStatus = db.StudentStatus.Find(id);
        //    if (studentStatus == null)
        //    {
        //        return NotFound();
        //    }

        //    db.StudentStatus.Remove(studentStatus);
        //    db.SaveChanges();

        //    return Ok(studentStatus);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool StudentStatusExists(int id)
        //{
        //    return db.StudentStatus.Count(e => e.Id == id) > 0;
        //}
    }
}