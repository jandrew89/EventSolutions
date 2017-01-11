namespace Shows.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendence : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        ShowId = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                        Attendee_Subject = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ShowId, t.AttendeeId })
                .ForeignKey("dbo.Users", t => t.Attendee_Subject)
                .ForeignKey("dbo.Shows", t => t.ShowId)
                .Index(t => t.ShowId)
                .Index(t => t.Attendee_Subject);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Subject = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        Password = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Subject);
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Subject = c.String(maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Subject)
                .Index(t => t.Subject);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        Subject = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        User_Subject = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Subject)
                .ForeignKey("dbo.Users", t => t.User_Subject)
                .Index(t => t.User_Subject);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "ShowId", "dbo.Shows");
            DropForeignKey("dbo.Attendances", "Attendee_Subject", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "User_Subject", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "Subject", "dbo.Users");
            DropIndex("dbo.UserLogins", new[] { "User_Subject" });
            DropIndex("dbo.UserClaims", new[] { "Subject" });
            DropIndex("dbo.Attendances", new[] { "Attendee_Subject" });
            DropIndex("dbo.Attendances", new[] { "ShowId" });
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Attendances");
        }
    }
}
