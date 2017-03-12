namespace Blackboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentspls2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Announcements", "Relationship_relationshipId", c => c.Int());
            CreateIndex("dbo.Announcements", "Relationship_relationshipId");
            AddForeignKey("dbo.Announcements", "Relationship_relationshipId", "dbo.Relationships", "relationshipId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Announcements", "Relationship_relationshipId", "dbo.Relationships");
            DropIndex("dbo.Announcements", new[] { "Relationship_relationshipId" });
            DropColumn("dbo.Announcements", "Relationship_relationshipId");
        }
    }
}
