namespace Test.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddredRequiredFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "StudentStatusId", "dbo.StudentStatus");
            DropIndex("dbo.Students", new[] { "StudentStatusId" });
            AlterColumn("dbo.Students", "StudentIdCard", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "StudentIdCard", c => c.String());
            CreateIndex("dbo.Students", "StudentStatusId");
            AddForeignKey("dbo.Students", "StudentStatusId", "dbo.StudentStatus", "Id", cascadeDelete: true);
        }
    }
}
