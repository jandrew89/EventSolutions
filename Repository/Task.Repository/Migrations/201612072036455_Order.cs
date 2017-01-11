namespace Task.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Order : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Tasks",
                c => new
                    {
                        TaskId = c.Guid(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.TaskId);
            
            CreateTable(
                "dbo.UserTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        IsCompleted = c.Boolean(nullable: false),
                        Commments = c.String(),
                        TimeOfDay = c.Int(nullable: false),
                        Task_TaskId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tasks", t => t.Task_TaskId)
                .Index(t => t.Task_TaskId);
            
            AddColumn("dbo.Customers", "Order_OrderId", c => c.Guid());
            AddColumn("dbo.Employees", "Order_OrderId", c => c.Guid());
            CreateIndex("dbo.Customers", "Order_OrderId");
            CreateIndex("dbo.Employees", "Order_OrderId");
            AddForeignKey("dbo.Customers", "Order_OrderId", "dbo.Orders", "OrderId");
            AddForeignKey("dbo.Employees", "Order_OrderId", "dbo.Orders", "OrderId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTasks", "Task_TaskId", "dbo.Tasks");
            DropForeignKey("dbo.Employees", "Order_OrderId", "dbo.Orders");
            DropForeignKey("dbo.Customers", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.UserTasks", new[] { "Task_TaskId" });
            DropIndex("dbo.Employees", new[] { "Order_OrderId" });
            DropIndex("dbo.Customers", new[] { "Order_OrderId" });
            DropColumn("dbo.Employees", "Order_OrderId");
            DropColumn("dbo.Customers", "Order_OrderId");
            DropTable("dbo.UserTasks");
            DropTable("dbo.Tasks");
            DropTable("dbo.Orders");
        }
    }
}
