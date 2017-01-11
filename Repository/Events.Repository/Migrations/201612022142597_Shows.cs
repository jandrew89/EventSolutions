namespace Shows.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Shows : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Followings", "Followee_Id", "dbo.Profiles");
            DropForeignKey("dbo.Attendances", "Attendee_Id", "dbo.Profiles");
            DropForeignKey("dbo.Followings", "Follower_Id", "dbo.Profiles");
            DropIndex("dbo.Attendances", new[] { "Attendee_Id" });
            DropIndex("dbo.Followings", new[] { "Followee_Id" });
            RenameColumn(table: "dbo.Followings", name: "Follower_Id", newName: "ArtistId");
            RenameIndex(table: "dbo.Followings", name: "IX_Follower_Id", newName: "IX_ArtistId");
            DropPrimaryKey("dbo.Followings");
            AddColumn("dbo.Followings", "UserId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Followings", new[] { "UserId", "ArtistId" });
            AddForeignKey("dbo.Followings", "ArtistId", "dbo.Profiles", "Id", cascadeDelete: true);
            DropColumn("dbo.Attendances", "Attendee_Id");
            DropColumn("dbo.Followings", "FollowerId");
            DropColumn("dbo.Followings", "FolloweeId");
            DropColumn("dbo.Followings", "Followee_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Followings", "Followee_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Followings", "FolloweeId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Followings", "FollowerId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Attendances", "Attendee_Id", c => c.Int());
            DropForeignKey("dbo.Followings", "ArtistId", "dbo.Profiles");
            DropPrimaryKey("dbo.Followings");
            DropColumn("dbo.Followings", "UserId");
            AddPrimaryKey("dbo.Followings", new[] { "FollowerId", "FolloweeId" });
            RenameIndex(table: "dbo.Followings", name: "IX_ArtistId", newName: "IX_Follower_Id");
            RenameColumn(table: "dbo.Followings", name: "ArtistId", newName: "Follower_Id");
            CreateIndex("dbo.Followings", "Followee_Id");
            CreateIndex("dbo.Attendances", "Attendee_Id");
            AddForeignKey("dbo.Followings", "Follower_Id", "dbo.Profiles", "Id");
            AddForeignKey("dbo.Attendances", "Attendee_Id", "dbo.Profiles", "Id");
            AddForeignKey("dbo.Followings", "Followee_Id", "dbo.Profiles", "Id");
        }
    }
}
