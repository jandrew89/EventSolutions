namespace Shows.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notification : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Shows", newName: "Events");
            RenameColumn(table: "dbo.Attendances", name: "ShowId", newName: "EventId");
            RenameIndex(table: "dbo.Attendances", name: "IX_ShowId", newName: "IX_EventId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Attendances", name: "IX_EventId", newName: "IX_ShowId");
            RenameColumn(table: "dbo.Attendances", name: "EventId", newName: "ShowId");
            RenameTable(name: "dbo.Events", newName: "Shows");
        }
    }
}
