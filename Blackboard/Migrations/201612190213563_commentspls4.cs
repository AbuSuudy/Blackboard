namespace Blackboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentspls4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Relationships", "announcementRelationship_Id", "dbo.Announcements");
            DropForeignKey("dbo.Announcements", "Relationship_relationshipId", "dbo.Relationships");
            DropForeignKey("dbo.Relationships", "commentRelationship_commentId", "dbo.Comments");
            DropIndex("dbo.Announcements", new[] { "Relationship_relationshipId" });
            DropIndex("dbo.Relationships", new[] { "announcementRelationship_Id" });
            DropIndex("dbo.Relationships", new[] { "commentRelationship_commentId" });
            DropColumn("dbo.Announcements", "Relationship_relationshipId");
            DropTable("dbo.Relationships");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Relationships",
                c => new
                    {
                        relationshipId = c.Int(nullable: false, identity: true),
                        announcementRelationship_Id = c.Int(),
                        commentRelationship_commentId = c.Int(),
                    })
                .PrimaryKey(t => t.relationshipId);
            
            AddColumn("dbo.Announcements", "Relationship_relationshipId", c => c.Int());
            CreateIndex("dbo.Relationships", "commentRelationship_commentId");
            CreateIndex("dbo.Relationships", "announcementRelationship_Id");
            CreateIndex("dbo.Announcements", "Relationship_relationshipId");
            AddForeignKey("dbo.Relationships", "commentRelationship_commentId", "dbo.Comments", "commentId");
            AddForeignKey("dbo.Announcements", "Relationship_relationshipId", "dbo.Relationships", "relationshipId");
            AddForeignKey("dbo.Relationships", "announcementRelationship_Id", "dbo.Announcements", "Id");
        }
    }
}
