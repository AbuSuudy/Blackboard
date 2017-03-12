namespace Blackboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentsRequired4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "CommentString", c => c.String(nullable: false, maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "CommentString", c => c.String());
        }
    }
}
