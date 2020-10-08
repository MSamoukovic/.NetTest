﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data.Models;

namespace Test.Services.Interface
{
    interface ICourseService
    {
        List<Course> GetAllCourses();
        void CreateCourse(Course course);
        List<Student> GetStudentsByCourseId(int courseId);
    }
}
