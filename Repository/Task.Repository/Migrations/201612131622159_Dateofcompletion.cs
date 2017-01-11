namespace Assignment.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dateofcompletion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAssignments", "DateOfCompletion", c => c.DateTime(nullable: false));
            AddColumn("dbo.UserAssignments", "DateOfAssignment", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAssignments", "DateOfAssignment");
            DropColumn("dbo.UserAssignments", "DateOfCompletion");
        }
    }
}
