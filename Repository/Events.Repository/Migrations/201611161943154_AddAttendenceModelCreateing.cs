namespace Shows.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAttendenceModelCreateing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "ShowId", "dbo.Shows");
            AddForeignKey("dbo.Attendances", "ShowId", "dbo.Shows", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "ShowId", "dbo.Shows");
            AddForeignKey("dbo.Attendances", "ShowId", "dbo.Shows", "Id", cascadeDelete: true);
        }
    }
}
