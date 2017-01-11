namespace Assignment.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reassign : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAssignments", "Reassigned", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAssignments", "Reassigned");
        }
    }
}
