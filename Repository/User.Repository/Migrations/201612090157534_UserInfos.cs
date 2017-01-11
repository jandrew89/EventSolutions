namespace User.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInfos : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.UserInfoes");
            AlterColumn("dbo.UserInfoes", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.UserInfoes", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserInfoes");
            AlterColumn("dbo.UserInfoes", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.UserInfoes", "Id");
        }
    }
}
