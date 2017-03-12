namespace Blackboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blackboard3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Announcements", "Title", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Announcements", "Description", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Announcements", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Announcements", "Title", c => c.String(nullable: false));
        }
    }
}
