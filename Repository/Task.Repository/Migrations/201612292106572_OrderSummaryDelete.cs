namespace Assignment.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderSummaryDelete : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderProducts", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.OrderProducts", new[] { "Order_OrderId" });
            DropTable("dbo.OrderProducts");
            DropTable("dbo.Orders");
        }
        
        public override void Down()
        {
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
                        OrderCompleteDate = c.DateTime(nullable: false),
                        TimeToDelivery = c.Time(nullable: false, precision: 7),
                        OrderInstructions = c.String(),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.OrderProducts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Quantity = c.Int(),
                        Order_OrderId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.OrderProducts", "Order_OrderId");
            AddForeignKey("dbo.OrderProducts", "Order_OrderId", "dbo.Orders", "OrderId");
        }
    }
}
