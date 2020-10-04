using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Test.Data.Models;
using Test.Models;

namespace Test.Helpers
{
    public static class StudentHelper
    {
        public static Student UpdatedNonNullFields(Student student, StudentDTO studentDTO)
        {
            Student updatedStudent = new Student();

            if (studentDTO.FirstName != null)
                updatedStudent.FirstName = studentDTO.FirstName;
            if (studentDTO.FirstName == null)
                updatedStudent.FirstName = student.FirstName;

            if (studentDTO.LastName == null)
                updatedStudent.LastName = student.LastName;
            if (studentDTO.LastName != null)
                updatedStudent.LastName = studentDTO.LastName;

            if (String.IsNullOrEmpty(studentDTO.Year.ToString()))
                updatedStudent.Year = student.Year;
            if (!String.IsNullOrEmpty(studentDTO.Year.ToString()))
                updatedStudent.Year = studentDTO.Year;

            if (studentDTO.StudentIdCard == null)
                updatedStudent.StudentIdCard = student.StudentIdCard;
            if (studentDTO.StudentIdCard != null)
                updatedStudent.StudentIdCard = studentDTO.StudentIdCard;

            updatedStudent.StudentStatusId = student.StudentStatusId;
            return updatedStudent;
        }
    }
}