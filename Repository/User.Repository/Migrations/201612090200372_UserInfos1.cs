namespace User.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInfos1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.UserInfoes", name: "UserSubject_Subject", newName: "User_Subject");
            RenameIndex(table: "dbo.UserInfoes", name: "IX_UserSubject_Subject", newName: "IX_User_Subject");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.UserInfoes", name: "IX_User_Subject", newName: "IX_UserSubject_Subject");
            RenameColumn(table: "dbo.UserInfoes", name: "User_Subject", newName: "UserSubject_Subject");
        }
    }
}
