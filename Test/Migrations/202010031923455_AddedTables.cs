namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "FirstName", c => c.String());
            AddColumn("dbo.Students", "LastName", c => c.String());
            AddColumn("dbo.Students", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "StudentStatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "StudentIdCard", c => c.String());
            CreateIndex("dbo.Students", "StudentStatusId");
            AddForeignKey("dbo.Students", "StudentStatusId", "dbo.StudentStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "StudentStatusId", "dbo.StudentStatus");
            DropIndex("dbo.Students", new[] { "StudentStatusId" });
            AlterColumn("dbo.Students", "StudentIdCard", c => c.Int(nullable: false));
            DropColumn("dbo.Students", "StudentStatusId");
            DropColumn("dbo.Students", "Year");
            DropColumn("dbo.Students", "LastName");
            DropColumn("dbo.Students", "FirstName");
        }
    }
}
