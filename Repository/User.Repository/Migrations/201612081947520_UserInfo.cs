namespace User.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserInfoes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Title = c.String(),
                        ReportsTo = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        HireDate = c.DateTime(nullable: false),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        PostalCode = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Role = c.String(),
                        UserSubject_Subject = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserSubject_Subject, cascadeDelete: true)
                .Index(t => t.UserSubject_Subject);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserInfoes", "UserSubject_Subject", "dbo.Users");
            DropIndex("dbo.UserInfoes", new[] { "UserSubject_Subject" });
            DropTable("dbo.UserInfoes");
        }
    }
}
