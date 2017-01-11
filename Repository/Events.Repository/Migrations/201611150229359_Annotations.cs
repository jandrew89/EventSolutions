namespace Shows.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Annotations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shows", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Shows", new[] { "Genre_Id" });
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Shows", "Venue", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Shows", "Genre_Id", c => c.Byte(nullable: false));
            CreateIndex("dbo.Shows", "Genre_Id");
            AddForeignKey("dbo.Shows", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shows", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Shows", new[] { "Genre_Id" });
            AlterColumn("dbo.Shows", "Genre_Id", c => c.Byte());
            AlterColumn("dbo.Shows", "Venue", c => c.String());
            AlterColumn("dbo.Genres", "Name", c => c.String());
            CreateIndex("dbo.Shows", "Genre_Id");
            AddForeignKey("dbo.Shows", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
