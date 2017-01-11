namespace Assignment.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrderEnum : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees");
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            RenameColumn(table: "dbo.Orders", name: "Customer_Id", newName: "CreatedBy_Id");
            RenameIndex(table: "dbo.Orders", name: "IX_Customer_Id", newName: "IX_CreatedBy_Id");
            AddColumn("dbo.Orders", "RoleAssignment", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Priority", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Assignment_AssignmentId", c => c.Guid());
            AddColumn("dbo.UserAssignments", "Priority", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Assignment_AssignmentId");
            AddForeignKey("dbo.Orders", "Assignment_AssignmentId", "dbo.Assignments", "AssignmentId");
            DropColumn("dbo.Orders", "Employee_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Employee_Id", c => c.Int());
            DropForeignKey("dbo.Orders", "Assignment_AssignmentId", "dbo.Assignments");
            DropIndex("dbo.Orders", new[] { "Assignment_AssignmentId" });
            DropColumn("dbo.UserAssignments", "Priority");
            DropColumn("dbo.Orders", "Assignment_AssignmentId");
            DropColumn("dbo.Orders", "Priority");
            DropColumn("dbo.Orders", "Status");
            DropColumn("dbo.Orders", "RoleAssignment");
            RenameIndex(table: "dbo.Orders", name: "IX_CreatedBy_Id", newName: "IX_Customer_Id");
            RenameColumn(table: "dbo.Orders", name: "CreatedBy_Id", newName: "Customer_Id");
            CreateIndex("dbo.Orders", "Employee_Id");
            AddForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees", "Id");
        }
    }
}
