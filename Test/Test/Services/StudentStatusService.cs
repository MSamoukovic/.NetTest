using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Test.Data;
using Test.Data.Models;
using Test.Services.Interface;

namespace Test.Services
{
    public class StudentStatusService : Service, IStudentStatusService
    {
        public StudentStatusService(TestContext context) : base(context)
        {
        }

        public List<StudentStatus> GetAllStudentStatus()
        {
            return Context.StudentStatus.ToList();
        }
    }
}