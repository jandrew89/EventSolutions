namespace Assignment.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderSummaryUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Guid(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderPlacementDate = c.DateTime(nullable: false),
                        OrderDeliveryDate = c.DateTime(nullable: false),
                        TimeToDelivery = c.Time(nullable: false, precision: 7),
                        OrderInstructions = c.String(),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.OrderSummaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Order_OrderId = c.Guid(),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.Order_OrderId)
                .ForeignKey("dbo.OrderProducts", t => t.Product_Id)
                .Index(t => t.Order_OrderId)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderSummaries", "Product_Id", "dbo.OrderProducts");
            DropForeignKey("dbo.OrderSummaries", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.OrderSummaries", new[] { "Product_Id" });
            DropIndex("dbo.OrderSummaries", new[] { "Order_OrderId" });
            DropTable("dbo.OrderSummaries");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderProducts");
        }
    }
}
