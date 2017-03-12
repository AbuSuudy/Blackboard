namespace Blackboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blackboard2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Announcements", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Announcements", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Announcements", "Description", c => c.String());
            AlterColumn("dbo.Announcements", "Title", c => c.String());
        }
    }
}
