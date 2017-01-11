namespace Shows.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserClaims", "Subject", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "User_Subject", "dbo.Users");
            DropForeignKey("dbo.Attendances", "Attendee_Subject", "dbo.Users");
            DropForeignKey("dbo.Attendances", "ShowId", "dbo.Shows");
            DropIndex("dbo.Attendances", new[] { "ShowId" });
            DropIndex("dbo.Attendances", new[] { "Attendee_Subject" });
            DropIndex("dbo.UserClaims", new[] { "Subject" });
            DropIndex("dbo.UserLogins", new[] { "User_Subject" });
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.Attendances");
            DropTable("dbo.Users");
            DropTable("dbo.UserClaims");
            DropTable("dbo.UserLogins");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        Subject = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        User_Subject = c.String(maxLength: 128),
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
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Attendances",
                c => new
                    {
                        ShowId = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                        Attendee_Subject = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ShowId, t.AttendeeId });
            
            DropTable("dbo.Profiles");
            CreateIndex("dbo.UserLogins", "User_Subject");
            CreateIndex("dbo.UserClaims", "Subject");
            CreateIndex("dbo.Attendances", "Attendee_Subject");
            CreateIndex("dbo.Attendances", "ShowId");
            AddForeignKey("dbo.Attendances", "ShowId", "dbo.Shows", "Id");
            AddForeignKey("dbo.Attendances", "Attendee_Subject", "dbo.Users", "Subject");
            AddForeignKey("dbo.UserLogins", "User_Subject", "dbo.Users", "Subject");
            AddForeignKey("dbo.UserClaims", "Subject", "dbo.Users", "Subject");
        }
    }
}
