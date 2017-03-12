namespace Blackboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blackboard4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Announcements", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Announcements", "Description", c => c.String(nullable: false, maxLength: 1000));
        }
    }
}
