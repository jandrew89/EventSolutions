namespace Assignment.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Request : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAssignments", "Requests", c => c.String());
            AddColumn("dbo.UserAssignments", "Response", c => c.String());
            DropColumn("dbo.UserAssignments", "Commments");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAssignments", "Commments", c => c.String());
            DropColumn("dbo.UserAssignments", "Response");
            DropColumn("dbo.UserAssignments", "Requests");
        }
    }
}
