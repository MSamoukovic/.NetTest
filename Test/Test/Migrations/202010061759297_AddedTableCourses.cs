namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTableCourses : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Name", c => c.Int(nullable: false));
        }
    }
}
