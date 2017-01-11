namespace User.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveHome : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.UserClaims", "Home");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserClaims", "Home", c => c.String());
        }
    }
}
