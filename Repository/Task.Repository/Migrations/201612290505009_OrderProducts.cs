namespace Assignment.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderProducts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Assignment_AssignmentId", "dbo.Assignments");
            DropForeignKey("dbo.Orders", "CreatedBy_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Assignment_AssignmentId" });
            DropIndex("dbo.Orders", new[] { "CreatedBy_Id" });
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Guid(nullable: false),
                        OrderType = c.Int(nullable: false),
                        RoleAssignment = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderPlacementDate = c.DateTime(nullable: false),
                        OrderCompleteDate = c.DateTime(nullable: false),
                        TimeToDelivery = c.Time(nullable: false, precision: 7),
                        Assignment_AssignmentId = c.Guid(),
                        CreatedBy_Id = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateIndex("dbo.Orders", "CreatedBy_Id");
            CreateIndex("dbo.Orders", "Assignment_AssignmentId");
            AddForeignKey("dbo.Orders", "CreatedBy_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Orders", "Assignment_AssignmentId", "dbo.Assignments", "AssignmentId");
        }
    }
}
