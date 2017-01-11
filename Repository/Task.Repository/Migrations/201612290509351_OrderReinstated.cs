namespace Assignment.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderReinstated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(),
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
                        CustomerId = c.Int(nullable: false),
                        RoleAssignment = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderPlacementDate = c.DateTime(nullable: false),
                        OrderCompleteDate = c.DateTime(nullable: false),
                        TimeToDelivery = c.Time(nullable: false, precision: 7),
                        OrderInstructions = c.String(),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderProducts", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.OrderProducts", new[] { "Order_OrderId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderProducts");
        }
    }
}
