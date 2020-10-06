using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            var statusId = Context.StudentStatus.Where(s => s.Name == studentDTO.StudentStatus).FirstOrDefault().Id;

            student.StudentStatusId = statusId;

            Context.Students.Add(student);
            Context.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = Context.Students.Where(s => s.Id == id).FirstOrDefault();
            Context.Students.Remove(student);
            Context.SaveChanges();
        }

        public List<StudentDTO> GetAllStudents()
        {
            //return Context.Database.SqlQuery<Student>("GetStudents").ToList();
            List<StudentDTO> allStudents = new List<StudentDTO>();
            foreach (var student in Context.Students)
            {
                StudentDTO stud = new StudentDTO();
                stud.Id = student.Id;
                stud.FirstName = student.FirstName;
                stud.LastName = student.LastName;
                stud.Year = student.Year;
                stud.StudentIdCard = student.StudentIdCard;
                var statusName = Context.StudentStatus.Where(s => s.Id == student.StudentStatusId).FirstOrDefault().Name;
                stud.StudentStatus = statusName;
                allStudents.Add(stud);
            }
            return allStudents;
        }

        public Student GetStudentById(int id)
        {
            //var student = Context.Students.Find(id);
            //return student;
            var studentIdParameter = new SqlParameter("@Id", id);
            var result = Context.Database
                .SqlQuery<Student>("GetById @Id", studentIdParameter)
                .ToList().FirstOrDefault();
            return result;
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