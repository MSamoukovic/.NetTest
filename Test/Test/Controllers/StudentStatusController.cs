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
    }
}