namespace Shows.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendence1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        ShowId = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                        Attendee_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.ShowId, t.AttendeeId })
                .ForeignKey("dbo.Profiles", t => t.Attendee_Id)
                .ForeignKey("dbo.Shows", t => t.ShowId, cascadeDelete: true)
                .Index(t => t.ShowId)
                .Index(t => t.Attendee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "ShowId", "dbo.Shows");
            DropForeignKey("dbo.Attendances", "Attendee_Id", "dbo.Profiles");
            DropIndex("dbo.Attendances", new[] { "Attendee_Id" });
            DropIndex("dbo.Attendances", new[] { "ShowId" });
            DropTable("dbo.Attendances");
        }
    }
}
