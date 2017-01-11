namespace Assignment.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Employees", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.Customers", new[] { "Order_OrderId" });
            DropIndex("dbo.Employees", new[] { "Order_OrderId" });
            AddColumn("dbo.Orders", "OrderPlacementDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "OrderCompleteDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "TimeToDelivery", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Orders", "Customer_Id", c => c.Int());
            AddColumn("dbo.Orders", "Employee_Id", c => c.Int());
            AlterColumn("dbo.Employees", "Role", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "Customer_Id");
            CreateIndex("dbo.Orders", "Employee_Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id");
            AddForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees", "Id");
            DropColumn("dbo.Customers", "Order_OrderId");
            DropColumn("dbo.Employees", "Order_OrderId");
            DropColumn("dbo.Orders", "OrderDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "OrderDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Employees", "Order_OrderId", c => c.Guid());
            AddColumn("dbo.Customers", "Order_OrderId", c => c.Guid());
            DropForeignKey("dbo.Orders", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Employee_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            AlterColumn("dbo.Employees", "Role", c => c.String());
            DropColumn("dbo.Orders", "Employee_Id");
            DropColumn("dbo.Orders", "Customer_Id");
            DropColumn("dbo.Orders", "TimeToDelivery");
            DropColumn("dbo.Orders", "OrderCompleteDate");
            DropColumn("dbo.Orders", "OrderPlacementDate");
            CreateIndex("dbo.Employees", "Order_OrderId");
            CreateIndex("dbo.Customers", "Order_OrderId");
            AddForeignKey("dbo.Employees", "Order_OrderId", "dbo.Orders", "OrderId");
            AddForeignKey("dbo.Customers", "Order_OrderId", "dbo.Orders", "OrderId");
        }
    }
}
