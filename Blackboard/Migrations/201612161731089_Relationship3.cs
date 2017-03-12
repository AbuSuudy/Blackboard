namespace Blackboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relationship3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Relationships",
                c => new
                    {
                        relationshipId = c.Int(nullable: false, identity: true),
                        announcementRelationship_Id = c.Int(),
                        commentRelationship_commentId = c.Int(),
                    })
                .PrimaryKey(t => t.relationshipId)
                .ForeignKey("dbo.Announcements", t => t.announcementRelationship_Id)
                .ForeignKey("dbo.Comments", t => t.commentRelationship_commentId)
                .Index(t => t.announcementRelationship_Id)
                .Index(t => t.commentRelationship_commentId);
            
            AddColumn("dbo.Comments", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Comments", "User_Id");
            AddForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Relationships", "commentRelationship_commentId", "dbo.Comments");
            DropForeignKey("dbo.Relationships", "announcementRelationship_Id", "dbo.Announcements");
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Relationships", new[] { "commentRelationship_commentId" });
            DropIndex("dbo.Relationships", new[] { "announcementRelationship_Id" });
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropColumn("dbo.Comments", "User_Id");
            DropTable("dbo.Relationships");
        }
    }
}
