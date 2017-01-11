namespace Assignment.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StatusUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAssignments", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAssignments", "Status");
        }
    }
}
