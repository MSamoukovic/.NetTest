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

           
        }
    }
}
