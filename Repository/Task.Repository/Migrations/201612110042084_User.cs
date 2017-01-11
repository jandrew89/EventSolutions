namespace Assignment.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class User : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAssignments", "Employee_Id", c => c.Int());
            CreateIndex("dbo.UserAssignments", "Employee_Id");
            AddForeignKey("dbo.UserAssignments", "Employee_Id", "dbo.Employees", "Id");
            DropColumn("dbo.UserAssignments", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAssignments", "EmployeeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.UserAssignments", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.UserAssignments", new[] { "Employee_Id" });
            DropColumn("dbo.UserAssignments", "Employee_Id");
        }
    }
}
