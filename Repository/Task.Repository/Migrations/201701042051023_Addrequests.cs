namespace Assignment.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addrequests : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignments", "Requests", c => c.String());
            DropColumn("dbo.UserAssignments", "TimeOfDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAssignments", "TimeOfDay", c => c.Int(nullable: false));
            DropColumn("dbo.Assignments", "Requests");
        }
    }
}
