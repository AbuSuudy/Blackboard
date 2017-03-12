namespace Blackboard.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blackboard7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        commentID = c.Int(nullable: false, identity: true),
                        comment = c.String(),
                    })
                .PrimaryKey(t => t.commentID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}
