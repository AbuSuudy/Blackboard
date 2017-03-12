namespace Blackboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentspls3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "Announcement_Id", c => c.Int());
            CreateIndex("dbo.Comments", "Announcement_Id");
            AddForeignKey("dbo.Comments", "Announcement_Id", "dbo.Announcements", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "Announcement_Id", "dbo.Announcements");
            DropIndex("dbo.Comments", new[] { "Announcement_Id" });
            DropColumn("dbo.Comments", "Announcement_Id");
        }
    }
}
