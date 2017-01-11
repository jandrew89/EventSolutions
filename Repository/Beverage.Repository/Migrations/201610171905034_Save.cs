namespace Beverage.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Save : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beverages",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CoffeeId = c.Int(nullable: false),
                    TeaId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Cars",
                c => new
                {
                    CarId = c.Int(nullable: false, identity: true),
                    Year = c.Int(nullable: false),
                    Manufacturer = c.String(),
                    Name = c.String(),
                    Displacement = c.Double(nullable: false),
                    Cylinders = c.Int(nullable: false),
                    City = c.Int(nullable: false),
                    Highway = c.Int(nullable: false),
                    Combined = c.Int(nullable: false),
                    Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Customer_CustomerId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.CarId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId, cascadeDelete: true)
                .Index(t => t.Customer_CustomerId);

            CreateTable(
                "dbo.Customers",
                c => new
                {
                    CustomerId = c.Int(nullable: false, identity: true),
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
                })
                .PrimaryKey(t => t.CustomerId);

            CreateTable(
                "dbo.DynamicProperties",
                c => new
                    {
                        Key = c.String(nullable: false, maxLength: 128),
                        CarsId = c.Int(nullable: false),
                        SerializedValue = c.String(),
                        Car_CarId = c.Int(),
                    })
                .PrimaryKey(t => new { t.Key, t.CarsId })
                .ForeignKey("dbo.Cars", t => t.Car_CarId)
                .Index(t => t.Car_CarId);

            CreateTable(
                "dbo.Coffees",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CoffeeType = c.Int(nullable: false),
                    Cost = c.Int(nullable: false),
                    Name = c.String(),
                    Notes = c.String(),
                    Region = c.String(),
                    Acidity = c.String(),
                    Body = c.String(),
                    Elevation = c.String(),
                    Variental = c.String(),
                    Decaf = c.Boolean(nullable: false),
                    SignOff = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Teas",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    BrewingMethod = c.String(),
                    Caffinated = c.Boolean(nullable: false),
                    Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Name = c.String(),
                    Notes = c.String(),
                    Sourced = c.String(),
                    TeaType = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.CustomerCustomers",
                c => new
                {
                    Customer_CustomerId = c.Int(nullable: false),
                    Customer_CustomerId1 = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Customer_CustomerId, t.Customer_CustomerId1 })
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId1)
                .Index(t => t.Customer_CustomerId)
                .Index(t => t.Customer_CustomerId1);

        }

        public override void Down()
        {
            DropForeignKey("dbo.DynamicProperties", "Car_CarId", "dbo.Cars");
            DropForeignKey("dbo.CustomerCustomers", "Customer_CustomerId1", "dbo.Customers");
            DropForeignKey("dbo.CustomerCustomers", "Customer_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Cars", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.CustomerCustomers", new[] { "Customer_CustomerId1" });
            DropIndex("dbo.CustomerCustomers", new[] { "Customer_CustomerId" });
            DropIndex("dbo.DynamicProperties", new[] { "Car_CarId" });
            DropIndex("dbo.Cars", new[] { "Customer_CustomerId" });
            DropTable("dbo.CustomerCustomers");
            DropTable("dbo.Teas");
            DropTable("dbo.Coffees");
            DropTable("dbo.DynamicProperties");
            DropTable("dbo.Customers");
            DropTable("dbo.Cars");
            DropTable("dbo.Beverages");
        }
    }
}
