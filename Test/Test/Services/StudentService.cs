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
            Student student = ConvertDTOToStudent(studentDTO);
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
            List<StudentDTO> allStudents = new List<StudentDTO>();
            var storeProcedure = Context.Database.SqlQuery<Student>("GetStudents").ToList();
            foreach (var student in storeProcedure)
            {
                StudentDTO studentDTO = ConvertStudentToDTO(student);
                allStudents.Add(studentDTO);
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
            student.StudentStatusId = updatedStudent.StudentStatusId;
            Context.SaveChanges();
        }

        public Student ConvertDTOToStudent(StudentDTO studentDTO)
        {
            Student student = new Student();
            student.StudentIdCard = studentDTO.StudentIdCard;
            student.FirstName = studentDTO.FirstName;
            student.LastName = studentDTO.LastName;
            student.Year = studentDTO.Year;

            var statusId = Context.StudentStatus.Where(s => s.Name == studentDTO.StudentStatus).FirstOrDefault().Id;
            student.StudentStatusId = statusId;
            return student;
        }

        public StudentDTO ConvertStudentToDTO(Student student)
        {
            StudentDTO studentDTO = new StudentDTO();
            studentDTO.Id = student.Id;
            studentDTO.FirstName = student.FirstName;
            studentDTO.LastName = student.LastName;
            studentDTO.Year = student.Year;
            studentDTO.StudentIdCard = student.StudentIdCard;
            var statusName = Context.StudentStatus.Where(s => s.Id == student.StudentStatusId).FirstOrDefault().Name;
            studentDTO.StudentStatus = statusName;

            var courses = GetStudentsCourses(student);
            studentDTO.CoursesList = courses;

            return studentDTO;
        }

        public List<string> GetStudentsCourses(Student student)
        {
            var coursesList = Context.StudentCourses.Where(s => s.StudentId == student.Id).ToList();
            var courses = new List<string>();
            foreach (var course in coursesList)
            {
                var courseId = course.CourseId;
                var courseName = Context.Courses.Where(c => c.Id == courseId).FirstOrDefault().Name;
                courses.Add(courseName);
            }
            return courses;
        }
    }
}