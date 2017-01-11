namespace Shows.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Genre : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Shows", name: "Genre_Id", newName: "GenreId");
            RenameIndex(table: "dbo.Shows", name: "IX_Genre_Id", newName: "IX_GenreId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Shows", name: "IX_GenreId", newName: "IX_Genre_Id");
            RenameColumn(table: "dbo.Shows", name: "GenreId", newName: "Genre_Id");
        }
    }
}
