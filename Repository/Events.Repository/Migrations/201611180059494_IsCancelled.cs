namespace Shows.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsCancelled : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shows", "Artist_Id", "dbo.Profiles");
            DropIndex("dbo.Shows", new[] { "Artist_Id" });
            AddColumn("dbo.Shows", "IsCanceled", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Shows", "Artist_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Shows", "Artist_Id");
            AddForeignKey("dbo.Shows", "Artist_Id", "dbo.Profiles", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shows", "Artist_Id", "dbo.Profiles");
            DropIndex("dbo.Shows", new[] { "Artist_Id" });
            AlterColumn("dbo.Shows", "Artist_Id", c => c.Int());
            DropColumn("dbo.Shows", "IsCanceled");
            CreateIndex("dbo.Shows", "Artist_Id");
            AddForeignKey("dbo.Shows", "Artist_Id", "dbo.Profiles", "Id");
        }
    }
}
