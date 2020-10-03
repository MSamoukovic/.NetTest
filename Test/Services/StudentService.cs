using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Test.Data;
using Test.Data.Models;
using Test.Helpers;
using Test.Models;
using Test.Services.Interface;

namespace Test.Services
{
    public class StudentService : Service, IStudentService
    {
        public StudentService(TestContext context) : base(context)
        {
        }

        public void CreateStudent(StudentDTO studentDTO)
        {
            Student student = new Student();
            student.StudentIdCard = studentDTO.StudentIdCard;
            student.FirstName = studentDTO.FirstName;
            student.LastName = studentDTO.LastName;
            student.Year = studentDTO.Year;
            student.StudentStatusId = 1;

            Context.Students.Add(student);
            Context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = Context.Students.Where(s => s.Id == id).FirstOrDefault();
            Context.Students.Remove(student);
            Context.SaveChanges();
        }

        public List<Student> GetAllStudents()
        {
            List<Student> allStudents = new List<Student>();
            foreach (var student in Context.Students)
            {
                allStudents.Add(student);
            }
            return allStudents;
        }

        public Student GetStudentById(int id)
        {
            var student = Context.Students.Find(id);
            return student;
        }

        public void UpdateStudent(int id, StudentDTO studentDTO)
        {
            Student student = Context.Students.Find(id);
            var updatedStudent  = StudentHelper.UpdatedNonNullFields(student, studentDTO);

            student.FirstName = updatedStudent.FirstName;
            student.LastName = updatedStudent.LastName;
            student.Year = updatedStudent.Year;
            student.StudentIdCard = updatedStudent.StudentIdCard;
            Context.SaveChanges();
        }
    }
}