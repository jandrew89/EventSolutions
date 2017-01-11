namespace Shows.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArtist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shows", "Artist_Id", c => c.Int());
            CreateIndex("dbo.Shows", "Artist_Id");
            AddForeignKey("dbo.Shows", "Artist_Id", "dbo.Profiles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shows", "Artist_Id", "dbo.Profiles");
            DropIndex("dbo.Shows", new[] { "Artist_Id" });
            DropColumn("dbo.Shows", "Artist_Id");
        }
    }
}
