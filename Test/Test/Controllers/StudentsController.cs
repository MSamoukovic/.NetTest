using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Test.Data;
using Test.Data.Models;
using Test.Models;
using Test.Services;

namespace Test.Controllers
{
    public class StudentsController : ApiController
    {
        StudentService student = new StudentService(new TestContext());

        // GET api/students
        public IEnumerable<Student> Get()
        {
            var allStudents = student.GetAllStudents();
            return allStudents;
        }

        // GET api/students/5
        public Student Get(int id)
        {
            return student.GetStudentById(id);
        }
        
        // DELETE api/students/5
        public void Delete(int id)
        {
            student.DeleteStudent(id);
        }

        // POST api/students
        [Route("api/init-data-entery")]
        public void Post([FromBody] StudentDTO studentDTO)
        {
            student.CreateStudent(studentDTO);
        }

        // PUT api/students/5
        public void Put(int id, [FromBody] StudentDTO studentDTO)
        {
            student.UpdateStudent(id, studentDTO);
        }
    }
}
