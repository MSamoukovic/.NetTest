using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
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

            AddCoursesOfStudent(student.Id, studentDTO.CoursesList);           
        }

        public void DeleteStudent(int id)
        {
            var student = Context.Students.Where(s => s.Id == id).FirstOrDefault();
            Context.Students.Remove(student);
            Context.SaveChanges();

            var coursesOdStudent = Context.CoursesOfStudents.Where(s => s.StudentId == id).ToList();
            foreach(var courseOfStudent in coursesOdStudent)
            {
                Context.CoursesOfStudents.Remove(courseOfStudent);
                Context.SaveChanges();
            }
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

        public StudentDTO GetStudentById(int id)
        {
            //var student = Context.Students.Find(id);
            //return student;
            var studentIdParameter = new SqlParameter("@Id", id);
            var student = Context.Database
                .SqlQuery<Student>("GetById @Id", studentIdParameter)
                .ToList().FirstOrDefault();
            var studentDTO = ConvertStudentToDTO(student);
            return studentDTO;

        }

        public void UpdateStudent(int id, StudentDTO studentDTO)
        {
            Student student = Context.Students.Find(id);

            student.FirstName = studentDTO.FirstName;
            student.LastName = studentDTO.LastName;
            student.Year = studentDTO.Year;
            student.StudentIdCard = studentDTO.StudentIdCard;
            var statusId = Context.StudentStatus.Where(s => s.Name == studentDTO.StudentStatus).FirstOrDefault().Id;
            student.StudentStatusId = statusId;

            var coursesOfStudent = Context.CoursesOfStudents.Where(s => s.StudentId == student.Id).ToList();
            foreach (var course in coursesOfStudent)
            {
                Context.CoursesOfStudents.Remove(course);
            }

            foreach (var course in studentDTO.CoursesList)
            {
                var courseId = Context.Courses.Where(c => c.Name == course).FirstOrDefault().Id;
                StudentCourse courseOfStudent = new StudentCourse();
                courseOfStudent.CourseId = courseId;
                courseOfStudent.StudentId = student.Id;
                Context.CoursesOfStudents.Add(courseOfStudent);
                Context.SaveChanges();
            }
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
            var coursesList = Context.CoursesOfStudents.Where(s => s.StudentId == student.Id).ToList();
            var courses = new List<string>();
            foreach (var course in coursesList)
            {
                var courseId = course.CourseId;
                var courseName = Context.Courses.Where(c => c.Id == courseId).FirstOrDefault().Name;
                courses.Add(courseName);
            }
            return courses;
        }

        public void AddCoursesOfStudent(int studentId, List<string> coursesNames)
        {
            foreach (var courseName in coursesNames)
            {
                var courseId = Context.Courses.Where(c => c.Name == courseName).FirstOrDefault().Id;
                StudentCourse studentCourse = new StudentCourse();
                studentCourse.StudentId = studentId;
                studentCourse.CourseId = courseId;
                Context.CoursesOfStudents.Add(studentCourse);
                Context.SaveChanges();
            }
        }
    }
}