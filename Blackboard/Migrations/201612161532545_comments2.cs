namespace Blackboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comments2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "commentString", c => c.String());
            DropColumn("dbo.Comments", "comment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "comment", c => c.String());
            DropColumn("dbo.Comments", "commentString");
        }
    }
}
