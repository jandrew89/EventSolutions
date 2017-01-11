namespace Assignment.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderRole : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Orders", "RoleAssignment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "RoleAssignment", c => c.Int(nullable: false));
        }
    }
}
