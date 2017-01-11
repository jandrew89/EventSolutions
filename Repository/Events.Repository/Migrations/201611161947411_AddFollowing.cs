namespace Shows.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowing : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followings",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                        Follower_Id = c.Int(nullable: false),
                        Followee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId })
                .ForeignKey("dbo.Profiles", t => t.Follower_Id)
                .ForeignKey("dbo.Profiles", t => t.Followee_Id)
                .Index(t => t.Follower_Id)
                .Index(t => t.Followee_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "Followee_Id", "dbo.Profiles");
            DropForeignKey("dbo.Followings", "Follower_Id", "dbo.Profiles");
            DropIndex("dbo.Followings", new[] { "Followee_Id" });
            DropIndex("dbo.Followings", new[] { "Follower_Id" });
            DropTable("dbo.Followings");
        }
    }
}
