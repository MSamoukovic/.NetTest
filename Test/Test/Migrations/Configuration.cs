namespace Test.Migrations
{
    using Test.Data.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web.UI.WebControls;

    internal sealed class Configuration : DbMigrationsConfiguration<Test.Data.TestContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.TestContext context)
        {
            context.StudentStatus.AddOrUpdate(
              t => t.Id,
              new StudentStatus { Id = 1, Name = "Redovan" },
              new StudentStatus { Id = 2, Name = "Vanredan" }
            );

            context.Students.AddOrUpdate(
             t => t.Id,
             new Student { Id = 1, StudentIdCard="MR12/15", FirstName = "Maja", LastName="Samoukovic", Year=4, StudentStatusId=2 },
             new Student { Id = 2, StudentIdCard = "MR14/15", FirstName = "Vanja", LastName = "Samoukovic", Year = 1, StudentStatusId = 1 }
           );

            context.Courses.AddOrUpdate(
             t => t.Id,
             new Course { Id = 1, Name = "Engleski"},
             new Course { Id = 2, Name = "Francuski" },
             new Course { Id = 3, Name = "Njemaèki" }
           );

            context.StudentCourses.AddOrUpdate(
             t => t.Id,
             new StudentCourse { Id = 1, StudentId = 1, CourseId=1 },
             new StudentCourse { Id = 2, StudentId = 1, CourseId = 2 },
             new StudentCourse { Id = 3, StudentId = 2, CourseId = 1 }
           );
        }
    }
}
