using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Models;
using Test.Models;

namespace Test.Services.Interface
{
    interface IStudentService
    {
        List<StudentDTO> GetAllStudents();
        Student GetStudentById(int id);
        void DeleteStudent(int id);
        void CreateStudent(StudentDTO studentDTO);
        void UpdateStudent(int id, StudentDTO studentDTO);
    }
}
