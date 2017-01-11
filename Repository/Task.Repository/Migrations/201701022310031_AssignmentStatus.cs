namespace Assignment.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AssignmentStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Assignments", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Assignments", "CompletedDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Assignments", "CompletedDate");
            DropColumn("dbo.Assignments", "Status");
        }
    }
}
