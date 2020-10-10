namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTableName1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Name", c => c.String());
        }
    }
}
