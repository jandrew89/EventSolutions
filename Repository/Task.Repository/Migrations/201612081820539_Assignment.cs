namespace Assignment.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Assignment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignments",
                c => new
                    {
                        AssignmentId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.AssignmentId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Company = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        PostalCode = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Order_OrderId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Title = c.String(),
                        ReportsTo = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        PostalCode = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Role = c.String(),
                        Order_OrderId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .Index(t => t.Order_OrderId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Guid(nullable: false),
                        OrderType = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.UserAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        Commments = c.String(),
                        TimeOfDay = c.Int(nullable: false),
                        Assignment_AssignmentId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assignments", t => t.Assignment_AssignmentId)
                .Index(t => t.Assignment_AssignmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAssignments", "Assignment_AssignmentId", "dbo.Assignments");
            DropForeignKey("dbo.Employees", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Customers", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.UserAssignments", new[] { "Assignment_AssignmentId" });
            DropIndex("dbo.Employees", new[] { "Order_OrderId" });
            DropIndex("dbo.Customers", new[] { "Order_OrderId" });
            DropTable("dbo.UserAssignments");
            DropTable("dbo.Orders");
            DropTable("dbo.Employees");
            DropTable("dbo.Customers");
            DropTable("dbo.Assignments");
        }
    }
}
