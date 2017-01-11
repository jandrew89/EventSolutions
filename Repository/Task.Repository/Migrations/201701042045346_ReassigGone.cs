namespace Assignment.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReassigGone : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserAssignments", "Requests");
            DropColumn("dbo.UserAssignments", "Reassigned");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAssignments", "Reassigned", c => c.Boolean(nullable: false));
            AddColumn("dbo.UserAssignments", "Requests", c => c.String());
        }
    }
}
