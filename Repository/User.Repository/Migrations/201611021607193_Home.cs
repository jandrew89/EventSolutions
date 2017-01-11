namespace User.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Home : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserClaims", "Home", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserClaims", "Home");
        }
    }
}
