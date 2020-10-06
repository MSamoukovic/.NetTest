using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Models;

namespace Test.Services.Interface
{
    interface IStudentStatusService
    {
        List<StudentStatus> GetAllStudentStatus();
    }
}
